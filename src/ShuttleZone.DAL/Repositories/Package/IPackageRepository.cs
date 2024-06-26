using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Interfaces;

namespace ShuttleZone.DAL.DependencyInjection.Repositories.Package;

[AutoRegister]
public interface IPackageRepository : IGenericRepository<Domain.Entities.Package>
{
    
}