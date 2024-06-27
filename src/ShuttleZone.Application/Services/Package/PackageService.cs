using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Domain.Enums;
using ShuttleZone.Domain.WebRequests.Packages;
using ShuttleZone.Domain.WebResponses.Package;

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
            await _unitOfWork.PackageRepository.AddAsync(package);
            await _unitOfWork.CompleteAsync();
            return createPackageDto;
        }

        throw new Exception();
    }

    public IQueryable<PackageResponseDto>? GetPackagesAdmin()
    {
        var packages = _unitOfWork.PackageRepository.GetAll();
        if (packages != null)
        {
            var packagesDtos = _mapper.ProjectTo<PackageResponseDto>(packages);
            return packagesDtos;

        }
        return null;
    }

    public async Task<UpdatePackageDto> UpdatePackage(UpdatePackageDto updatePackageDto)
    {
        var package = await _unitOfWork.PackageRepository.Find(p => p.Id == updatePackageDto.Id).FirstAsync();
        if (package != null)
        {
            package.Name = updatePackageDto.Name;
            package.Description = updatePackageDto.Description;
            package.Price = updatePackageDto.Price;

             _unitOfWork.PackageRepository.Update(package);
             await _unitOfWork.CompleteAsync();
             return updatePackageDto;
        }

        throw new KeyNotFoundException();
    }
}