using AutoMapper;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests.Packages;

namespace ShuttleZone.Application.AutoMapper;

public class PackageMappingProfile : Profile
{
    public PackageMappingProfile()
    {
        CreateMap<CreatePackageDto, Package>();
    }
}