using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Common.Attributes;
using ShuttleZone.Common.Exceptions;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Domain.Entities;
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
            package.PackageStatus = PackageStatus.INVALID;
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

    public async Task<bool> DeletePackage(Guid packageId)
    {
        var package = await _unitOfWork.PackageRepository.Find(p => p.Id == packageId)
            .Include(p => p.PackageUser)
            .FirstAsync();
        if (package != null)
        {
            if (package.PackageUser?.Count == 0 || package.PackageUser == null)
            {
                _unitOfWork.PackageRepository.Delete(package);
                await _unitOfWork.CompleteAsync();
                return true;
            }

            throw new Exception("Package is currently in use by managers !");
        }

        return false;
    }

    public async Task<bool> UpdateStatus(Guid packageId)
    {
        var package = await _unitOfWork.PackageRepository.Find(p => p.Id == packageId)
            .FirstAsync();
        if (package != null)
        {
            if (package.PackageStatus == PackageStatus.VALID)
            {
                package.PackageStatus = PackageStatus.INVALID;
                 _unitOfWork.PackageRepository.Update(package);
                 await _unitOfWork.CompleteAsync();
                 return true;
            }else if (package.PackageStatus == PackageStatus.INVALID)
            {
                package.PackageStatus = PackageStatus.VALID;
                _unitOfWork.PackageRepository.Update(package);
                await _unitOfWork.CompleteAsync();
                return true;
            }
        }
        throw new KeyNotFoundException();
    }

    public  UserPackageResponseDto GetCurrentUserPackage(Guid userId)
    {
        var package = _unitOfWork.PackageRepository
            .Find(p => p.PackageUser != null &&
                       p.PackageUser.Select(pu => pu.UserId)
                           .Contains(userId) &&
                       p.PackageUser.Any(pu => pu.PackageUserStatus == PackageUserStatus.VALID))
            .Include(p => p.PackageUser)
            .FirstOrDefault();
        var dto = _mapper.Map<UserPackageResponseDto>(package);

        return dto;
    }

    public List<UserPackageResponseDto> GetUserPackageHistory(Guid userId)
    {
        var package = _unitOfWork.PackageRepository
            .GetAll()
            .Include(p => p.PackageUser)
            .ToList();
        var dto = _mapper.Map<List<UserPackageResponseDto>>(package);

        return dto;
    }

    public async Task<bool> SubPackageManager(SubPackageDto subPackageDto, Guid userId)
    {
        
        var package = await _unitOfWork.PackageRepository.GetAsync(p => p.Id == subPackageDto.packageId);
        if (package == null)
            throw new InvalidOperationException("Package not found !");
        
        var userWallet = await _unitOfWork.WalletRepository.GetAsync(w => w.UserId == userId);
        if (userWallet == null)
        {
            throw new InvalidOperationException("User does not have wallet yet !");
        }
        if(userWallet.Balance < (double)package.Price)
        {
            throw new ArgumentException("Balance is insufficient !");
        }
        
        
        var addTransaction = new Transaction
        {
            Id = new Guid(),
            PaymentMethod = PaymentMethod.WALLET,
            Amount = (double)package.Price,
            TransactionStatus = TransactionStatusEnum.SUCCESS,
            Created = DateTime.Now,
            CreatedBy = userId.ToString(),
            TransactionDate = DateTime.Now.ToString(),
        };
        
        await _unitOfWork.TransactionRepository.AddAsync(addTransaction);
        await _unitOfWork.CompleteAsync();
        
        var packageUser = new PackageUser
        {
            Id = new Guid(),
            UserId = userId,
            PackageId = package.Id,
            TransactionId = addTransaction.Id,
            StartDate = DateTime.Now,
            EndDate = DateTime.Now
        };

        await _unitOfWork.PackageUserRepository.AddAsync(packageUser);
        await _unitOfWork.CompleteAsync();

        return true;
    }
}