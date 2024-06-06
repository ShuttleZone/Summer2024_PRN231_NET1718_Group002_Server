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
}