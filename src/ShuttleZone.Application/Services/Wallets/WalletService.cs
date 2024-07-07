﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Common.Attributes;
using ShuttleZone.Common.Constants;
using ShuttleZone.Common.Exceptions;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.Enums;
using ShuttleZone.Domain.WebRequests.Payment;
using ShuttleZone.Domain.WebResponses.Wallets;

namespace ShuttleZone.Application.Services.Wallets
{
    [AutoRegister]
    public class WalletService(IUnitOfWork _unitOfWork, IMapper _mapper, IUser _user) : IWalletService
    {
        public async Task<WalletResponse> GetMyWalletAsync(Guid currentUserId)
        {
            var wallet = await _unitOfWork.WalletRepository.GetAsync(w => w.UserId == currentUserId);
            if (wallet == null)
            {
                wallet = new Domain.Entities.Wallet()
                {
                    Id = new Guid(),
                    UserId = currentUserId,
                    Balance = 0
                };
                await _unitOfWork.WalletRepository.AddAsync(wallet);
                await _unitOfWork.CompleteAsync();
            }

            return _mapper.Map<WalletResponse>(wallet);
        }

        public async Task<IQueryable<WalletResponse>> GetWalletsAsync()
        {
            return (await _unitOfWork.WalletRepository.GetAllAsync())
                .ProjectTo<WalletResponse>(_mapper.ConfigurationProvider);
        }

        public async Task PutWalletAsync(Guid walletId, VnPayRequest request)
        {
            var wallet = await _unitOfWork.WalletRepository.GetAsync(w => w.Id == walletId) ?? throw new HttpException(400, "Invalid wallet");

            wallet.Balance += request.Amount;
            var transaction = new Domain.Entities.Transaction()
            {
                Id = new Guid(),
                PaymentMethod = PaymentMethod.WALLET,
                Amount = request.Amount,
                TransactionStatus = TransactionStatusEnum.SUCCESS,
            };

            if (request.OrderType.Equals(VnPayConstansts.ORDER_TYPE_BOOKING, StringComparison.OrdinalIgnoreCase))
            {
                var reservationId = new Guid(request.OrderInfo ?? throw new Exception("Invalid reservation"));
                var reservation = _unitOfWork.ReservationRepository.Find(r => r.Id == reservationId)
                    .Include(r => r.ReservationDetails).FirstOrDefault();

                if (reservation != null)
                {
                    foreach (var detail in reservation.ReservationDetails)
                    {
                        detail.ReservationDetailStatus = ReservationStatusEnum.PAYSUCCEED;
                    }

                    reservation.ReservationStatusEnum = ReservationStatusEnum.PAYSUCCEED;
                }

            }
            else if (request.OrderType.Equals(VnPayConstansts.ORDER_TYPE_JOIN_CONTEST, StringComparison.OrdinalIgnoreCase))
            {
                var contestId = new Guid(request.OrderInfo ?? throw new Exception("Invalid reservation"));
                var user = await _unitOfWork.UserRepository.Find(u => u.Id == wallet.UserId).FirstOrDefaultAsync() ?? throw new Exception("Invalid user");
                var contest = _unitOfWork.ContestRepository.Find(c => c.Id == contestId).Include(c => c.UserContests)
                    .Include(c => c.Reservation)
                    .FirstOrDefault()
            ?? throw new HttpException(400, $"Contest with id {contestId} is not existed");

                var reservationStartTime = _unitOfWork.ReservationRepository
                                         .Find(r => r.Id == contest.Reservation!.Id)
                                         .Include(r => r.ReservationDetails)
                                         .SelectMany(r => r.ReservationDetails.Select(rd => rd.StartTime))
                                         .Min();

                if (reservationStartTime < DateTime.Now)
                    throw new HttpException(400, $"Contest with id {contestId} is already happened");

                if (contest.ContestStatus == ContestStatusEnum.Closed)
                    throw new HttpException(400, $"Contest with id {contestId} is already closed");

                var isJoined = contest.UserContests.Exists(c => c.ParticipantsId == user.Id);
                if (isJoined)
                    throw new HttpException(400, $"You are already in this contest");

                var isSlotRemaining = contest.MaxPlayer > contest.UserContests.Count();
                if (!isSlotRemaining)
                    throw new HttpException(400, $"The contest is full slot");

                contest.UserContests.Add(
                    new UserContest
                    {
                        ParticipantsId = user.Id,
                        ContestId = contestId
                    });

            }
            else if (request.OrderType.Equals(VnPayConstansts.ORDER_TYPE_PACKAGE, StringComparison.OrdinalIgnoreCase))
            {
                var packageId = new Guid(request.OrderInfo ?? throw new Exception("Invalid package"));
                var package = await _unitOfWork.PackageRepository.GetAsync(p => p.Id == packageId) ?? throw new Exception("Invalid package");
                
                var packageCheck = await _unitOfWork.PackageUserRepository
                    .ExistsAsync(p => p.UserId == new Guid(_user.Id!)
                                      && p.PackageUserStatus == PackageUserStatus.VALID);
                if (packageCheck) throw new ArgumentException("Hiện tại người dùng đã đăng kí gói. Hãy huỷ gói hiện tại để sử dụng gói khác");
                
                await _unitOfWork.TransactionRepository.AddAsync(transaction);
                await _unitOfWork.CompleteAsync();
                var packageUser = new PackageUser
                {
                    Id = new Guid(),
                    UserId = new Guid(_user.Id ?? throw new HttpException(401, "You are not logined")),
                    PackageId = packageId,
                    TransactionId = transaction.Id,
                    StartDate = DateTime.Now,
                    EndDate = package.PackageType == PackageType.MONTH ? DateTime.Now.AddMonths(1)
                    : package.PackageType == PackageType.YEAR ? DateTime.Now.AddYears(1)
                    : DateTime.Now.AddYears(100000)
                };
                
             

                await _unitOfWork.PackageUserRepository.AddAsync(packageUser);

            }

            wallet.Transactions.Add(transaction);
            await _unitOfWork.CompleteAsync();

        }
    }
}
