using AutoMapper;
using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Domain.Enums;
using ShuttleZone.Domain.WebRequests.Packages;

namespace ShuttleZone.Application.DependencyInjection.Services.Package;

[AutoRegister]
public class PackageService : IPackageService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PackageService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<CreatePackageDto> CreatePackage(CreatePackageDto createPackageDto)
    {
        if (createPackageDto != null)
        {
            var package = _mapper.Map<Domain.Entities.Package>(createPackageDto);
            package.PackageStatus = PackageStatus.Pending;
            await _unitOfWork.PackageRepository.AddAsync(package);
            await _unitOfWork.CompleteAsync();
            return createPackageDto;
        }

        throw new Exception();
    }
}