using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Application.Services.Payment;
using ShuttleZone.Common.Attributes;
using ShuttleZone.Common.Constants;
using ShuttleZone.Common.Exceptions;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.Enums;
using ShuttleZone.Domain.WebRequests.Reservations;
using ShuttleZone.Domain.WebResponses.ReservationDetails;
using ShuttleZone.Domain.WebResponses.Reservations;

namespace ShuttleZone.Application.Services.Reservation
{
    [AutoRegister]
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IVnPayService _vnPayService;

        public ReservationService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager, IVnPayService vnPayService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _vnPayService = vnPayService;
        }

        public async Task CancelReservation(Guid reservationId)
        {
            var reservation = _unitOfWork.ReservationRepository.Find(r => r.Id == reservationId)
                .Include(r=>r.ReservationDetails)
                .FirstOrDefault();
            if (reservation == null)
                throw new HttpException(400, "Resevation is unexisted");

            if (//payment failed
                (reservation.ReservationStatusEnum == ReservationStatusEnum.PENDING && reservation.ExpiredTime < DateTime.Now)
                || reservation.ReservationStatusEnum == ReservationStatusEnum.PAYFAIL
                || reservation.ReservationStatusEnum == ReservationStatusEnum.CANCELLED)
            {
                var status = reservation.ReservationStatusEnum == Domain.Enums.ReservationStatusEnum.CANCELLED ? ReservationStatusEnum.CANCELLED.ToString().ToLower() : "pay failed";
                throw new HttpException(400, $"Reservation is already in {status} status");
            }
            if(reservation.ReservationDetails.Any(rd=>rd.ReservationDetailStatus == ReservationStatusEnum.CANCELLED))
                throw new HttpException(400, "Reservation contain cancel booked court. You have cancelled reservation detail, can not cancel this reservation");

            if (reservation.ReservationDetails.Any(r => r.StartTime < DateTime.Now))
                throw new HttpException(400, "Cannot cancel a reservation that has already started or is in the past.");

            var alloweCancelByTime = reservation.ReservationDetails.Any(r => DateTime.Now < r.StartTime.AddDays(-1));
            if (!alloweCancelByTime)
                throw new HttpException(400, "Reservation contain reservation detail that can only be cancelled 24 hours before the start time.");


            reservation.ReservationDetails.ToList().ForEach(d =>
            {
                d.ReservationDetailStatus = ReservationStatusEnum.CANCELLED;
            });

            if (reservation.ReservationStatusEnum == ReservationStatusEnum.PAYSUCCEED)
            {
                //will add refund here later
                await _vnPayService.RefundPaymentAsync(reservation.Id);
            }

            await _unitOfWork.CompleteAsync();
        }

        public async Task CancelReservationDetail(int reservationDetailId)
        {
            var reservationDetail = _unitOfWork.ReservationDetailRepository.Find(r => r.Id == reservationDetailId)
                .Include(r => r.Reservation)
                .FirstOrDefault();
            if (reservationDetail == null)
                throw new HttpException(400, "Court Booking is unexisted");

            if (//allow cancel only if payment successfully 
                (reservationDetail.ReservationDetailStatus == ReservationStatusEnum.PENDING && reservationDetail.Reservation.ExpiredTime < DateTime.Now)
                || reservationDetail.ReservationDetailStatus == ReservationStatusEnum.PAYFAIL
                || reservationDetail.ReservationDetailStatus == ReservationStatusEnum.CANCELLED)
            {
                var status = reservationDetail.ReservationDetailStatus == Domain.Enums.ReservationStatusEnum.CANCELLED ? ReservationStatusEnum.CANCELLED.ToString().ToLower() : "pay failed";
                throw new HttpException(400, $"Court Booking is already in {status} status");
            }

            if (reservationDetail.StartTime < DateTime.Now)
                throw new HttpException(400, "Cannot cancel a Court Booking that has already started or is in the past.");

            var alloweCancelByTime = DateTime.Now < reservationDetail.StartTime.AddDays(-1);
            if (!alloweCancelByTime)
                throw new HttpException(400, "Court Booking can only be cancelled 24 hours before the start time.");

            reservationDetail.ReservationDetailStatus = ReservationStatusEnum.CANCELLED;
            reservationDetail.Reservation.TotalPrice -= reservationDetail.Price;            

            if(reservationDetail.Reservation.ReservationStatusEnum == ReservationStatusEnum.PAYSUCCEED)
            {
                //will add refund here later
                await _vnPayService.RefundPaymentAsync(reservationDetail.Reservation.Id, reservationDetail.Price, VnPayConstansts.LESS_THAN_TOTAL_REFUND);
            }

            await _unitOfWork.CompleteAsync();

        }

        public async Task<bool> CreateReservation(CreateReservationRequest request, Guid? currentUser = null, bool isStaff = true)
        {
            var requestEntity = _mapper.Map<ShuttleZone.Domain.Entities.Reservation>(request);
            if (!isStaff)
            {
                var user = await _userManager.FindByIdAsync(currentUser.ToString()
                                                            ?? throw new ArgumentNullException("UserId is null"))
                    ?? throw new InvalidOperationException("User not found");
                requestEntity.CustomerId = currentUser;
            }


            if (request.ReservationDetails == null || !request.ReservationDetails.Any())
            {
                throw new ArgumentException("At least one ReservationDetail is required.");
            }
            else
            {
                foreach (var detail in request.ReservationDetails)
                {

                    if (detail.StartTime < DateTime.Now.AddMinutes(30))
                    {
                        throw new ArgumentException("That reservations can only be made for a time at least 30 minutes in the future.");
                    }
                    if (detail.StartTime >= detail.EndTime)
                    {
                        throw new ArgumentException("StartTime must be less than EndTime for ReservationDetails.");
                    }

                    var courtExisted = _unitOfWork.CourtRepository.Exists(c => c.Id == detail.CourtId);
                    if (!courtExisted)
                    {
                        throw new InvalidOperationException($"Court {detail.CourtId} does not exist.");
                    }

                    var hasOverlap = HasOverlappingReservation(detail.CourtId, detail.StartTime, detail.EndTime);
                    if (hasOverlap)
                    {
                        throw new InvalidOperationException($"Court {detail.CourtId} is already booked during the requested time.");
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
                .Where(r => r.CustomerId == currentUser)
                .Include(r => r.ReservationDetails)
                .ThenInclude(rd => rd.Court);

            var reservationsResponse = reservationsQuery
                .ProjectTo<ReservationResponse>(_mapper.ConfigurationProvider);

            return reservationsResponse;
        }

        public IQueryable<ReservationDetailsResponse> GetMyReservationDetails(Guid currentUser)
        {
            var reservationDetailsQuery = _unitOfWork.ReservationRepository.GetAll()
                .Where(r => r.CustomerId == currentUser)
                .Include(r => r.ReservationDetails)
                .SelectMany(r => r.ReservationDetails).Include(r => r.Court).ThenInclude(c => c.Club).Include(r=>r.Reservation);

            var reservationDetailsResponse = reservationDetailsQuery
                .ProjectTo<ReservationDetailsResponse>(_mapper.ConfigurationProvider);

            return reservationDetailsResponse;
        }

        public bool HasOverlappingReservation(Guid? courtId, DateTime startTime, DateTime endTime)
        {
            return _unitOfWork.ReservationDetailRepository.GetAll().Include(d => d.Reservation).
                                Any(d => (d.ReservationDetailStatus == Domain.Enums.ReservationStatusEnum.PAYSUCCEED
                                || (d.ReservationDetailStatus == Domain.Enums.ReservationStatusEnum.PENDING
                                && d.Reservation.ExpiredTime > DateTime.Now)) && d.CourtId == courtId &&
                                                         d.StartTime < endTime &&
                                                         d.EndTime > startTime);
        }
    }
}
