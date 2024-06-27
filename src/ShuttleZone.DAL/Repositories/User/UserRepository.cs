using Microsoft.EntityFrameworkCore;
using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Implementations;
using ShuttleZone.Infrastructure.Data.Interfaces;

namespace ShuttleZone.DAL.DependencyInjection.Repositories.User;
[AutoRegister]
public class UserRepository : GenericRepository<Domain.Entities.User>, IUserRepository
{
    public UserRepository(IApplicationDbContext context, IReadOnlyApplicationDbContext readOnlyContext) : base(context, readOnlyContext)
    {
    }

    public async Task AddBalanceAsync(Guid userId, double amount)
    {
        var user = (await GetAllAsync()).Include(u => u.Wallet).FirstOrDefault(x => x.Id == userId);

        if (user == null)
            throw new Exception("User not found");
        if (user.Wallet == null)
            user.Wallet = new Domain.Entities.Wallet { Id = Guid.NewGuid() };

        user.Wallet.Balance += amount;
    }
}