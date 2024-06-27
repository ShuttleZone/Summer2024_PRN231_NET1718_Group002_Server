using ShuttleZone.DAL.Common.Interfaces;

namespace ShuttleZone.DAL.DependencyInjection.Repositories.User;

public interface IUserRepository : IGenericRepository<Domain.Entities.User>
{
    Task AddBalanceAsync(Guid userId, double amount);

}