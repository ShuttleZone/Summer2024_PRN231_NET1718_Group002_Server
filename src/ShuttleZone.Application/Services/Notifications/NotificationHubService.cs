using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using ShuttleZone.Application.SignalRHub;
using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests.Notifications;
using ShuttleZone.Domain.WebResponses.Notifications;

namespace ShuttleZone.Application.Services.Notifications
{
    [AutoRegister]
    public class NotificationHubService(IHubContext<NotificationHub> _hubContext, IMapper _mapper) : INotificationHubService
    {
        public Notification CreateNotification(NotificationRequest request)
        {
            return _mapper.Map<Notification>(request);
        }

      
        public async Task SendNotificationAsync(Guid userId, NotificationResponse response)
        {
            if (NotificationHub.TryGetConnectionId(userId.ToString(), out var connectionId))
            {
                await _hubContext.Clients.Client(connectionId).SendAsync("ReceiveNotification", response);
            }
        }
    }
}
