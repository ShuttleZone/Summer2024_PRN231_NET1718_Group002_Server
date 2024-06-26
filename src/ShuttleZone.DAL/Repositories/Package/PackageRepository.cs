using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Implementations;
using ShuttleZone.Infrastructure.Data.Interfaces;

namespace ShuttleZone.DAL.DependencyInjection.Repositories.Package;

[AutoRegister]
public class PackageRepository : GenericRepository<Domain.Entities.Package>, IPackageRepository
{
    public PackageRepository(IApplicationDbContext context, IReadOnlyApplicationDbContext readOnlyContext) : base(context, readOnlyContext)
    {
    }
}