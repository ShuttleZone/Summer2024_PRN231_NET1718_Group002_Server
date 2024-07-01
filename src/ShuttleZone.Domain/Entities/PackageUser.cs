using ShuttleZone.Domain.Common;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities
{
    public class PackageUser : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        
        public Guid PackageId { get; set; }
        public Package Package { get; set; } = null!;
        
        public Guid TransactionId { get; set; }
        public Transaction? Transaction { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
    }
}
