namespace ShuttleZone.Domain.WebResponses.Notifications
{
    public class NotificationResponse
    {
        public Guid Id { get; set; } 
        public string Description { get; set; } = null!;
        public DateTime NotificationDate { get; set; }
        public bool IsRead { get; set; } = false;
        public Guid UserId { get; set; }
    }
}
