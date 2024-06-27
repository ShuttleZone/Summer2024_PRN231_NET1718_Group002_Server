using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Domain.WebResponses.Notifications;

namespace ShuttleZone.Application.Services.Notifications
{
    [AutoRegister]
    public class NotificationService(IUnitOfWork _unitOfWork, IMapper _mapper) : INotificationService
    {
        public async Task<IQueryable<NotificationResponse>> GetNotifications(Guid userId)
        {
            var notificationQueryable = (await _unitOfWork.NotificationRepository.GetAllAsync())
                .Where(x => x.UserId == userId);
            return notificationQueryable.ProjectTo<NotificationResponse>(_mapper.ConfigurationProvider);
        }

        public async Task ReadNotifications(Guid userId)
        {
            var notificationQueryable = (await _unitOfWork.NotificationRepository.GetAllAsync())
                .Where(x => x.UserId == userId && x.IsRead == false);

            foreach (var notification in notificationQueryable)
            {
                notification.IsRead = true;
            }
            await _unitOfWork.CompleteAsync();
        }
    }
}
