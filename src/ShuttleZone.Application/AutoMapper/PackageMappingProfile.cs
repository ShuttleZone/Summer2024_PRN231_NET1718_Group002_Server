using AutoMapper;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests.Packages;
using ShuttleZone.Domain.WebResponses.Package;

namespace ShuttleZone.Application.AutoMapper;

public class PackageMappingProfile : Profile
{
    public PackageMappingProfile()
    {
        CreateMap<CreatePackageDto, Package>();
        CreateMap<PackageResponseDto, Package>();
        CreateMap<Package, PackageResponseDto>();
        CreateMap<UpdatePackageDto, Package>();
    }
}