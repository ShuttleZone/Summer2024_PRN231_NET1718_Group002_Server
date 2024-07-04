using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Implementations;
using ShuttleZone.Infrastructure.Data.Interfaces;

namespace ShuttleZone.DAL.DependencyInjection.Repositories.PackageUser;

[AutoRegister]
public class PackageUserRepository : GenericRepository<Domain.Entities.PackageUser>,IPackageUserRepository
{
    public PackageUserRepository(IApplicationDbContext context, IReadOnlyApplicationDbContext readOnlyContext) : base(context, readOnlyContext)
    {
    }
}