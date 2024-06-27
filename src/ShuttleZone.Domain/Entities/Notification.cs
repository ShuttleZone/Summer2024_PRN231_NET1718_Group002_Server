using ShuttleZone.Domain.Common;

namespace ShuttleZone.Domain.Entities
{
    public class Notification : BaseEntity<Guid>
    {       
        public string Description { get; set; } = null!;
        public DateTime NotificationDate { get; set; } = DateTime.Now;
        public bool IsRead { get; set; } = false;
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
