using System.Globalization;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Application.Services.Email;
using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.DAL.DependencyInjection.Repositories.PackageUser;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Application.Services.Expiration;
[AutoRegister]
public class ExpirationService : IExpirationService
{
    private readonly IPackageUserRepository _packageUserRepository;
    private readonly IEmailService _emailService;
    private readonly IUnitOfWork _unitOfWork;

    public ExpirationService(IPackageUserRepository packageUserRepository, IUnitOfWork unitOfWork, IEmailService emailService)
    {
        _packageUserRepository = packageUserRepository;
        _unitOfWork = unitOfWork;
        _emailService = emailService;
    }
    public async Task ValidatePackageUser()
    {
        try
        {
            var packagesExpiringSoon = _packageUserRepository
                .Find(x => x.EndDate.Date >= DateTime.Now.Date && x.EndDate.Date <= DateTime.Now.AddDays(3).Date)
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
            }
        }   
        catch (Exception ex)
        {
            Console.Write(ex.Message);
        }
    }
}