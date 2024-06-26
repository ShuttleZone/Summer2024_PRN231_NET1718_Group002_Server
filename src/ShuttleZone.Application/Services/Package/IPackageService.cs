using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.WebRequests.Packages;

namespace ShuttleZone.Application.DependencyInjection.Services.Package;

[AutoRegister]
public interface IPackageService
{
    Task<CreatePackageDto> CreatePackage(CreatePackageDto createPackageDto);
}