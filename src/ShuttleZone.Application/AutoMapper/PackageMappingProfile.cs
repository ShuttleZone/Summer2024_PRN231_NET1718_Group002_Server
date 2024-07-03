using AutoMapper;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests.Packages;
using ShuttleZone.Domain.WebResponses.Package;
using PackageUser = ShuttleZone.Domain.Entities.PackageUser;

namespace ShuttleZone.Application.AutoMapper;

public class PackageMappingProfile : Profile
{
    public PackageMappingProfile()
    {
        CreateMap<CreatePackageDto, Package>();
        CreateMap<PackageResponseDto, Package>();
        CreateMap<Package, PackageResponseDto>();
        CreateMap<UpdatePackageDto, Package>();

        CreateMap<Package, UserPackageResponseDto>();
        CreateMap<PackageUser, UserPackageResponseDto.PackageUserDto>()
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(p => p.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(p => p.EndDate));
    }
}