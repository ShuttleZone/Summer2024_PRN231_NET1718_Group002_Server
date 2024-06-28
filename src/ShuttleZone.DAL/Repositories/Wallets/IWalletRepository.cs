using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.DAL.Repositories.Wallets
{
    public interface IWalletRepository : IGenericRepository<Wallet>
    {
       void UpdateWalletBalance(Guid userId, double balance);
    }
}
