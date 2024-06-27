using ShuttleZone.Domain.WebResponses.Notifications;

namespace ShuttleZone.Application.Services.Notifications
{
    public interface INotificationService
    {
        Task ReadNotifications(Guid userId);
        Task<IQueryable<NotificationResponse>> GetNotifications(Guid userId);
    }
}
