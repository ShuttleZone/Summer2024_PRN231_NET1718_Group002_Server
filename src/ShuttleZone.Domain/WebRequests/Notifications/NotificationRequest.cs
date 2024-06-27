using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Domain.WebRequests.Notifications
{
    public class NotificationRequest
    {
        public string Description { get; set; } = null!;
        public Guid UserId { get; set; }
    }
}
