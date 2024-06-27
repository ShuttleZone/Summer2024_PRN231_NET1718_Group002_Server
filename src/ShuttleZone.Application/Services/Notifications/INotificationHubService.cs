using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests.Notifications;
using ShuttleZone.Domain.WebResponses.Notifications;

namespace ShuttleZone.Application.Services.Notifications
{
    public interface INotificationHubService
    {
        Notification CreateNotification(NotificationRequest request);

        Task SendNotificationAsync(Guid userId, NotificationResponse response);
    }
}
