using ShuttleZone.DAL.Common.Implementations;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Infrastructure.Data.Interfaces;

namespace ShuttleZone.DAL.Repositories.Wallets
{
    public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(IApplicationDbContext context, IReadOnlyApplicationDbContext readOnlyContext) : base(context, readOnlyContext)
        {
        }

        public void UpdateWalletBalanceByUserId(Guid userId, double balance)
        {
            var wallet = Find(w => w.UserId == userId).FirstOrDefault();
            if (wallet != null)
            {
                wallet.Balance += balance;
            }
            else
            {
                var newWallet = new Wallet
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Balance = balance
                };
                Add(newWallet);
            }
        }

        public void UpdateWalletBalanceByWalletId(Guid walletId, double balance)
        {
            var wallet = Find(w => w.Id == walletId).FirstOrDefault() ?? throw new ArgumentNullException("Invalid wallet");

            wallet.Balance += balance;

        }
    }
}
