using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.WebRequests.Packages;
using ShuttleZone.Domain.WebResponses.Package;

namespace ShuttleZone.Application.DependencyInjection.Services.Package;

[AutoRegister]
public interface IPackageService
{
    Task<CreatePackageDto> CreatePackage(CreatePackageDto createPackageDto);

    IQueryable<PackageResponseDto>? GetPackagesAdmin();

    Task<UpdatePackageDto> UpdatePackage(UpdatePackageDto updatePackageDto);

    Task<bool> DeletePackage(Guid packageId);

    Task<bool> UpdateStatus(Guid packageId);
}