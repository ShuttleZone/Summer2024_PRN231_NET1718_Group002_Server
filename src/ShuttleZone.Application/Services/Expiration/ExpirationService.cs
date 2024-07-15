using System.Globalization;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Application.Services.Email;
using ShuttleZone.Application.Services.Notifications;
using ShuttleZone.Common.Attributes;
using ShuttleZone.Common.Exceptions;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.DAL.DependencyInjection.Repositories.PackageUser;
using ShuttleZone.DAL.Repositories;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.Enums;
using ShuttleZone.Domain.WebRequests.Notifications;
using ShuttleZone.Domain.WebResponses.Notifications;

namespace ShuttleZone.Application.Services.Expiration;
[AutoRegister]
public class ExpirationService(IPackageUserRepository _packageUserRepository, 
    IUnitOfWork _unitOfWork, 
    IEmailService _emailService, 
    IClubRepository _clubRepository,
    INotificationHubService _notificationHubService,
    IMapper _mapper) : IExpirationService
{ 
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

                //noti for user
                var notificationRequest = new NotificationRequest
                {
                    UserId = packageUser.UserId,
                    Description = $"Gói đăng ký câu lạc bộ của bạn hết hạn trong {remainingDays}. Hãy đăng ký gói lại đúng thời gian để câu lạc bộ hoạt động nhé.",
                };
                var notification = _notificationHubService.CreateNotification(notificationRequest);
                await _unitOfWork.NotificationRepository.AddAsync(notification);
                await _notificationHubService.SendNotificationAsync((Guid)packageUser.UserId, _mapper.Map<NotificationResponse>(notification));

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