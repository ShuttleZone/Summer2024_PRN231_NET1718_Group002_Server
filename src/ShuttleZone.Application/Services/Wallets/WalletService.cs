using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Common.Attributes;
using ShuttleZone.Common.Constants;
using ShuttleZone.Common.Exceptions;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Domain.Enums;
using ShuttleZone.Domain.WebRequests.Payment;
using ShuttleZone.Domain.WebResponses.Wallets;

namespace ShuttleZone.Application.Services.Wallets
{
    [AutoRegister]
    public class WalletService(IUnitOfWork _unitOfWork, IMapper _mapper) : IWalletService
    {
        public async Task<WalletResponse> GetMyWalletAsync(Guid currentUserId)
        {
            var wallet = await _unitOfWork.WalletRepository.GetAsync(w => w.UserId == currentUserId);

            return _mapper.Map<WalletResponse>(wallet);
        }

        public async Task<IQueryable<WalletResponse>> GetWalletsAsync()
        {
            return (await _unitOfWork.WalletRepository.GetAllAsync())
                .ProjectTo<WalletResponse>(_mapper.ConfigurationProvider);
        }

        public async Task<WalletResponse> PutWalletAsync(Guid walletId, VnPayRequest request)
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
            
            wallet.Transactions.Add(transaction);
            if (request.OrderType.Equals(VnPayConstansts.ORDER_TYPE_BOOKING, StringComparison.OrdinalIgnoreCase))
            {
                var reservationId = new Guid(request.OrderInfo ?? throw new Exception("Invalid reservation"));
                var reservation = _unitOfWork.ReservationRepository.Find(r => r.Id == reservationId)
                    .Include(r => r.ReservationDetails).FirstOrDefault();

                if (reservation != null)
                {
                    foreach (var detail in reservation.ReservationDetails)
                    {
                        detail.ReservationDetailStatus =  ReservationStatusEnum.PAYSUCCEED;
                    }

                    reservation.ReservationStatusEnum = ReservationStatusEnum.PAYSUCCEED;
                }

            }
            wallet.Transactions.Add(transaction);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<WalletResponse>(wallet);
        }
    }
}
