using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Interfaces;

namespace ShuttleZone.DAL.DependencyInjection.Repositories.PackageUser;
[AutoRegister]
public interface IPackageUserRepository : IGenericRepository<Domain.Entities.PackageUser>
{
    
}