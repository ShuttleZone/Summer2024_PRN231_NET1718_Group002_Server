using ShuttleZone.Domain.Common;

namespace ShuttleZone.Domain.Entities
{
    public class Wallet : BaseEntity<Guid>
    {
        public decimal Balance { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;    
      
    }
}
