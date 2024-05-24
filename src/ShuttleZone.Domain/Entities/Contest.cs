using ShuttleZone.Domain.Common;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities;

public class Contest : BaseAuditableEntity<Guid>
{   
    public DateTime ContestDate { get; set; }
    public int MaxPlayer { get; set; }
    public string? Policy { get; set; }
    public ContestStatusEnum ContestStatus { get; set; }
    
    public Reservation? Reservation { get; set; }
    public List<User> Participants = new List<User>();
}
