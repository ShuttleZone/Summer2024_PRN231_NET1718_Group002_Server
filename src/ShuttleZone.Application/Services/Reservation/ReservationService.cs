using AutoMapper;
using AutoMapper.QueryableExtensions;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Application.Services.Notifications;
using ShuttleZone.Common.Attributes;
using ShuttleZone.Common.Exceptions;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.Enums;
using ShuttleZone.Domain.WebRequests.Notifications;
using ShuttleZone.Domain.WebRequests.Reservations;
using ShuttleZone.Domain.WebResponses.Notifications;
using ShuttleZone.Domain.WebResponses.ReservationDetails;
using ShuttleZone.Domain.WebResponses.Reservations;
using System.Reflection;

namespace ShuttleZone.Application.Services.Reservation
{
    [AutoRegister]
    public class ReservationService(IUnitOfWork _unitOfWork, IMapper _mapper, UserManager<User> _userManager, INotificationHubService _notificationHubService) : IReservationService
    {
        public async Task CancelReservation(Guid reservationId)
        {
            var reservation = _unitOfWork.ReservationRepository.Find(r => r.Id == reservationId)
                .Include(r => r.ReservationDetails)
                .FirstOrDefault() ?? throw new HttpException(400, "Đặt chỗ không tồn tại");


            if (//payment failed
                (reservation.ReservationStatusEnum == ReservationStatusEnum.PENDING && reservation.ExpiredTime < DateTime.Now)
                || reservation.ReservationStatusEnum == ReservationStatusEnum.PAYFAIL
                || reservation.ReservationStatusEnum == ReservationStatusEnum.CANCELLED)
            {
                var status = reservation.ReservationStatusEnum == Domain.Enums.ReservationStatusEnum.CANCELLED ? ReservationStatusEnum.CANCELLED.ToString().ToLower() : "Thanh toán thất bại";
                throw new HttpException(400, $"Đặt chỗ đã ở trạng thái {status}. Bạn không cần hủy");
            }
            //if (reservation.ReservationDetails.Any(rd => rd.ReservationDetailStatus == ReservationStatusEnum.CANCELLED))
            //    throw new HttpException(400, "Reservation contain cancel booked court. You have cancelled reservation detail, can not cancel this reservation");

            if (reservation.ReservationDetails.Any(r => r.StartTime < DateTime.Now))
                throw new HttpException(400, "Không thể hủy đặt chỗ đã bắt đầu hoặc đã qua.");

            var alloweCancelByTime = reservation.ReservationDetails.Any(r => DateTime.Now < r.StartTime.AddDays(-1));
            if (!alloweCancelByTime)
                throw new HttpException(400, "Đặt chỗ chỉ có thể hủy 24 giờ trước thời gian bắt đầu.");

            var refundAmount = reservation.ReservationDetails.Where(rd => rd.ReservationDetailStatus == ReservationStatusEnum.PAYSUCCEED).Sum(rd => rd.Price);
            reservation.ReservationStatusEnum = ReservationStatusEnum.CANCELLED;
            reservation.ReservationDetails.ToList().ForEach(d =>
            {
                d.ReservationDetailStatus = ReservationStatusEnum.CANCELLED;
            });

            //option: add refund vnPay here later
            //await _vnPayService.RefundPaymentAsync(reservation.Id);
            if (refundAmount > 0)
            {
                //refund to wallet            
                //nhi: Jul 4 2024
                //improve later: should refund to all transaction have this reservationId cause if person create contest cancel reservation
                //all joined people need be refunded
                _unitOfWork.WalletRepository.UpdateWalletBalanceByUserId(reservation.CustomerId ?? Guid.Empty, refundAmount);

                var transaction = new Domain.Entities.Transaction()
                {
                    Id = new Guid(),
                    PaymentMethod = PaymentMethod.WALLET,
                    Amount = refundAmount,
                    TransactionStatus = TransactionStatusEnum.SUCCESS,
                };
                var wallet = await _unitOfWork.WalletRepository.GetAsync(w => w.UserId == reservation.CustomerId) ?? throw new HttpException(400, "Invalid wallet");
                wallet.Transactions.Add(transaction);

                //notifiy to user
                var notificationRequest = new NotificationRequest
                {
                    UserId = reservation.CustomerId ?? throw new HttpException(400, "Người dùng không hợp lệ"),
                    Description = $"Bạn đã hủy đặt chỗ. {refundAmount} VND đã được hoàn lại vào ví của bạn",
                };
                var notification = _notificationHubService.CreateNotification(notificationRequest);
                await _unitOfWork.NotificationRepository.AddAsync(notification);
                await _notificationHubService.SendNotificationAsync((Guid)reservation.CustomerId, _mapper.Map<NotificationResponse>(notification));

                //nhi: Jul 4 2024
                //TODO: should refund to all transaction have this reservationId cause if person create contest cancel reservation
                //all joined people need be refunded 
                var isReservationOfAContest = (await _unitOfWork.ContestRepository.GetAllAsync())
                    .Include(c => c.Reservation)
                    .Any(c => c.Reservation!.Id == reservation.Id);
                if (isReservationOfAContest)
                {
                    var contest = (await _unitOfWork.ContestRepository.GetAllAsync())
                    .Include(c => c.Reservation)
                    .Include(c => c.UserContests)
                    .Where(c => c.Reservation!.Id == reservation.Id).FirstOrDefault() ?? throw new ArgumentNullException();

                    var joinedPerson = contest.UserContests.FirstOrDefault(uc => !uc.isCreatedPerson) ?? throw new ArgumentNullException();

                    _unitOfWork.WalletRepository.UpdateWalletBalanceByUserId(joinedPerson.ParticipantsId, refundAmount);

                    var transactionOfJoinedPerson = new Domain.Entities.Transaction()
                    {
                        Id = new Guid(),
                        PaymentMethod = PaymentMethod.WALLET,
                        Amount = refundAmount,
                        TransactionStatus = TransactionStatusEnum.SUCCESS,
                    };
                    var walletOfJoinedPerson = await _unitOfWork.WalletRepository.GetAsync(w => w.UserId == joinedPerson.ParticipantsId) ?? throw new HttpException(400, "Ví không hợp lệ");
                    walletOfJoinedPerson.Transactions.Add(transactionOfJoinedPerson);

                    //notifiy to joined person
                    var notificationRequestOfJoinedPerson = new NotificationRequest
                    {
                        UserId = joinedPerson.ParticipantsId,
                        Description = $"Người tạo cuộc thi đã hủy cuộc thi. {refundAmount} VND đã được hoàn lại vào ví của bạn",
                    };
                    var notificationOfJoinedPerson = _notificationHubService.CreateNotification(notificationRequestOfJoinedPerson);
                    await _unitOfWork.NotificationRepository.AddAsync(notificationOfJoinedPerson);
                    await _notificationHubService.SendNotificationAsync(joinedPerson.ParticipantsId, _mapper.Map<NotificationResponse>(notificationOfJoinedPerson));
                }
            }

            await _unitOfWork.CompleteAsync();
        }

        public async Task CancelReservationDetail(int reservationDetailId)
        {
            var reservationDetail = _unitOfWork.ReservationDetailRepository.Find(r => r.Id == reservationDetailId)
                .Include(r => r.Reservation)
                .FirstOrDefault();
            if (reservationDetail == null)
                throw new HttpException(400, "Đặt chỗ không tồn tại");

            if (//pay failed
                (reservationDetail.ReservationDetailStatus == ReservationStatusEnum.PENDING && reservationDetail.Reservation.ExpiredTime < DateTime.Now)
                || reservationDetail.ReservationDetailStatus == ReservationStatusEnum.PAYFAIL
                || reservationDetail.ReservationDetailStatus == ReservationStatusEnum.CANCELLED)
            {
                var status = reservationDetail.ReservationDetailStatus == Domain.Enums.ReservationStatusEnum.CANCELLED ? ReservationStatusEnum.CANCELLED.ToString().ToLower() : "Thanh toán thất bại";
                throw new HttpException(400, $"Đặt chỗ đã ở trạng thái {status}. Bạn không cần hủy");
            }

            if (reservationDetail.StartTime < DateTime.Now)
                throw new HttpException(400, "Không thể hủy đặt chỗ đã bắt đầu.");

            var allowCancelByTime = DateTime.Now < reservationDetail.StartTime.AddHours(-12);
            if (!allowCancelByTime)
                throw new HttpException(400, "Đặt chỗ chỉ có thể hủy 12 giờ trước thời gian bắt đầu.");

            reservationDetail.ReservationDetailStatus = ReservationStatusEnum.CANCELLED;
            reservationDetail.Reservation.TotalPrice -= reservationDetail.Price;

            if (reservationDetail.ReservationDetailStatus == ReservationStatusEnum.PAYSUCCEED)
            {
                //refund to wallet
                _unitOfWork.WalletRepository.UpdateWalletBalanceByUserId(reservationDetail.Reservation.CustomerId ?? Guid.Empty, reservationDetail.Price);

                var transaction = new Domain.Entities.Transaction()
                {
                    Id = new Guid(),
                    PaymentMethod = PaymentMethod.WALLET,
                    Amount = reservationDetail.Price,
                    TransactionStatus = TransactionStatusEnum.SUCCESS,
                };
                var wallet = await _unitOfWork.WalletRepository.GetAsync(w => w.UserId == reservationDetail.Reservation.CustomerId) ?? throw new HttpException(400, "Ví không hợp lệ");
                wallet.Transactions.Add(transaction);

                //notifiy to user
                var notificationRequest = new NotificationRequest
                {
                    UserId = reservationDetail.Reservation.CustomerId ?? throw new HttpException(400, "Người dùng không hợp lệ"),
                    Description = $"Bạn đã hủy đặt chỗ. {reservationDetail.Price} VND đã được hoàn lại vào ví của bạn",
                };
                var notification = _notificationHubService.CreateNotification(notificationRequest);
                await _unitOfWork.NotificationRepository.AddAsync(notification);
                await _notificationHubService.SendNotificationAsync((Guid)reservationDetail.Reservation.CustomerId, _mapper.Map<NotificationResponse>(notification));

                //nhi: Jul 4 2024
                //TODO: should refund to all transaction have this reservationId cause if person create contest cancel reservation
                //all joined people need be refunded 
                var isReservationOfAContest = (await _unitOfWork.ContestRepository.GetAllAsync())
                    .Include(c => c.Reservation)
                    .Any(c => c.Reservation!.Id == reservationDetail.Reservation.Id);
                if (isReservationOfAContest)
                {
                    var contest = (await _unitOfWork.ContestRepository.GetAllAsync())                        
                    .Include(c => c.Reservation)
                    .Include(c=>c.UserContests)
                    .Where(c => c.Reservation!.Id == reservationDetail.ReservationId).FirstOrDefault() ?? throw new ArgumentNullException();

                    var joinedPerson = contest.UserContests.FirstOrDefault(uc => !uc.isCreatedPerson) ?? throw new ArgumentNullException();

                    _unitOfWork.WalletRepository.UpdateWalletBalanceByUserId(joinedPerson.ParticipantsId, reservationDetail.Price);

                    var transactionOfJoinedPerson = new Domain.Entities.Transaction()
                    {
                        Id = new Guid(),
                        PaymentMethod = PaymentMethod.WALLET,
                        Amount = reservationDetail.Price,
                        TransactionStatus = TransactionStatusEnum.SUCCESS,
                    };
                    var walletOfJoinedPerson = await _unitOfWork.WalletRepository.GetAsync(w => w.UserId == joinedPerson.ParticipantsId) ?? throw new HttpException(400, "Ví không hợp lệ");
                    walletOfJoinedPerson.Transactions.Add(transactionOfJoinedPerson);

                    //notifiy to joined person
                    var notificationRequestOfJoinedPerson = new NotificationRequest
                    {
                        UserId = joinedPerson.ParticipantsId,
                        Description = $"Người tạo cuộc thi đã hủy cuộc thi. {reservationDetail.Price} VND đã được hoàn lại vào ví của bạn",
                    };
                    var notificationOfJoinedPerson = _notificationHubService.CreateNotification(notificationRequestOfJoinedPerson);
                    await _unitOfWork.NotificationRepository.AddAsync(notificationOfJoinedPerson);
                    await _notificationHubService.SendNotificationAsync(joinedPerson.ParticipantsId, _mapper.Map<NotificationResponse>(notificationOfJoinedPerson));
                }
               
            }

            await _unitOfWork.CompleteAsync();


        }

        public async Task<bool> CreateReservation(CreateReservationRequest request, Guid? currentUser = null, bool isStaff = true)
        {
            var requestEntity = _mapper.Map<ShuttleZone.Domain.Entities.Reservation>(request);
            if (!isStaff)
            {
                var user = await _userManager.FindByIdAsync(currentUser.ToString()
                                                            ?? throw new ArgumentNullException("Người dùng không tồn tại"))
                    ?? throw new InvalidOperationException("Người dùng không tồn tại");
                requestEntity.CustomerId = currentUser;
            }


            if (request.ReservationDetails == null || !request.ReservationDetails.Any())
            {
                throw new ArgumentException("Cần ít nhất một đơn đặt chỗ.");
            }
            else
            {
                foreach (var detail in request.ReservationDetails)
                {

                    if (detail.StartTime < DateTime.Now.AddMinutes(30))
                    {
                        throw new ArgumentException("Đơn đặt chỗ phải được tạo ít nhất 30 phút trước thời gian bắt đầu.");
                    }
                    if (detail.StartTime >= detail.EndTime)
                    {
                        throw new ArgumentException("Thời gian bắt đầu phải trước thời gian kết thúc.");
                    }

                    var courtExisted = _unitOfWork.CourtRepository.Exists(c => c.Id == detail.CourtId);
                    if (!courtExisted)
                    {
                        throw new InvalidOperationException($"Sân không tồn tại.");
                    }

                    var clubEntity = _unitOfWork.CourtRepository.Find(c => c.Id == detail.CourtId)
                        .Include(c => c.Club)
                        .ThenInclude(club => club.OpenDateInWeeks).FirstOrDefault()?.Club;
                    if (clubEntity != null)
                    {
                        var dayOfWeekString = detail.StartTime.DayOfWeek.ToString();
                        bool isOpen = clubEntity.OpenDateInWeeks
                            .Any(openDate => openDate.Date.Equals(dayOfWeekString, StringComparison.OrdinalIgnoreCase));

                        if (!isOpen)
                        {
                            throw new ArgumentException($"Câu lạc bộ không mở cửa vào ngày {dayOfWeekString}.");
                        }
                    }

                    var hasOverlap = HasOverlappingReservation(detail.CourtId, detail.StartTime, detail.EndTime);
                    if (hasOverlap)
                    {
                        throw new InvalidOperationException($"Sân đã được đặt trước.");
                    }
                }
            }
            requestEntity.ExpiredTime = requestEntity.BookingDate.AddMinutes(10);
            await _unitOfWork.ReservationRepository.AddAsync(requestEntity);
            var addSuccess = await _unitOfWork.CompleteAsync();
            return addSuccess;
        }

        public IQueryable<ReservationResponse> GetMyReservation(Guid currentUser)
        {
            var reservationsQuery = _unitOfWork.ReservationRepository.GetAll()
                .Where(r => r.CustomerId == currentUser);

            reservationsQuery = reservationsQuery.Include(r => r.ReservationDetails)
                .ThenInclude(rd => rd.Court);

            var reservationsResponse = _mapper.Map<IList<ReservationResponse>>(reservationsQuery).AsQueryable();

            return reservationsResponse;
        }

        public IQueryable<ReservationDetailsResponse> GetMyReservationDetails(Guid currentUser)
        {
            var reservationDetailsQuery = _unitOfWork.ReservationRepository.GetAll()
                .Where(r => r.CustomerId == currentUser)
                .Include(r => r.ReservationDetails)
                .SelectMany(r => r.ReservationDetails).Include(r => r.Court).ThenInclude(c => c.Club).Include(r => r.Reservation);

            var reservationDetailsResponse = _mapper.Map<IList<ReservationDetailsResponse>>(reservationDetailsQuery).AsQueryable();

            return reservationDetailsResponse;
        }

        public bool HasOverlappingReservation(Guid? courtId, DateTime startTime, DateTime endTime)
        {
            return _unitOfWork.ReservationDetailRepository.GetAll().Include(d => d.Reservation).
                                Any(
                                d => (d.ReservationDetailStatus == Domain.Enums.ReservationStatusEnum.PAYSUCCEED
                                || (d.ReservationDetailStatus == Domain.Enums.ReservationStatusEnum.PENDING && d.Reservation.ExpiredTime > DateTime.Now))
                                && d.CourtId == courtId &&
                                (d.StartTime < endTime && d.EndTime > startTime)
                                );
        }
    }
}
