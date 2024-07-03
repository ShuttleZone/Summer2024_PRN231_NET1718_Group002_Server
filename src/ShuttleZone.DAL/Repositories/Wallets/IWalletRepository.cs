using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.DAL.Repositories.Wallets
{
    public interface IWalletRepository : IGenericRepository<Wallet>
    {
       void UpdateWalletBalanceByUserId(Guid userId, double balance);
       void UpdateWalletBalanceByWalletId(Guid walletId, double balance);


    }
}
