using System.Globalization;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Application.Services.Email;
using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.DAL.DependencyInjection.Repositories.PackageUser;
using ShuttleZone.DAL.Repositories;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Application.Services.Expiration;
[AutoRegister]
public class ExpirationService : IExpirationService
{
    private readonly IPackageUserRepository _packageUserRepository;
    private readonly IClubRepository _clubRepository;
    private readonly IEmailService _emailService;
    private readonly IUnitOfWork _unitOfWork;

    public ExpirationService(IPackageUserRepository packageUserRepository, IUnitOfWork unitOfWork, IEmailService emailService, IClubRepository clubRepository)
    {
        _packageUserRepository = packageUserRepository;
        _unitOfWork = unitOfWork;
        _emailService = emailService;
        _clubRepository = clubRepository;
    }
    public async Task ValidatePackageUser()
    {
        try
        {
            var packagesExpiringSoon = _packageUserRepository
                .Find(x => x.EndDate.Date >= DateTime.Now.Date && x.EndDate.Date <= DateTime.Now.AddDays(3).Date && x.PackageUserStatus == PackageUserStatus.VALID)
                .Include(x => x.User)
                .Include(x => x.Package)
                .ToList();
            if (packagesExpiringSoon.Count == 0)
                return;
            
            foreach (var packageUser in packagesExpiringSoon)
            {
                var emailObject = new ExpirationAnnouncementEmailObject()
                {
                    CustomerName = packageUser.User.Fullname,
                    UserEmail = packageUser.User.Email ?? "",
                    ExpirationDay = packageUser.EndDate.ToString(CultureInfo.InvariantCulture),
                    PackageName = packageUser.Package.Name,
                    RenewPackageUrl = "http://localhost:3000/home"
                };

                var remainingDays = (packageUser.EndDate.Date - DateTime.Now.Date).Days;
                emailObject.RemainingDays = remainingDays;
                await _emailService.SendExpirationPackageEmail(emailObject);
                
                if (remainingDays != 0) continue;
                packageUser.PackageUserStatus = PackageUserStatus.EXPIRED;
                _packageUserRepository.Update(packageUser);
                await _unitOfWork.CompleteAsync();
                
                await CloseClubsAsync(packageUser.UserId);
            }
        }   
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }

    private async Task CloseClubsAsync(Guid ownerId)
    {
        var clubs = _clubRepository!.Find(x => x.OwnerId == ownerId);
        foreach (var club in clubs)
        {
            club.ClubStatusEnum = ClubStatusEnum.Closed;
            _clubRepository.Update(club);
        }
        await _unitOfWork.CompleteAsync();
    }
}