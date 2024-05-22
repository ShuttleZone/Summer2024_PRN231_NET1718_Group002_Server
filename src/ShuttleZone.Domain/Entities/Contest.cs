using System.ComponentModel.DataAnnotations;
using ShuttleZone.Domain.Common;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities;

public class Contest : BaseAuditableEntity<Guid>
{   
    public DateTime ContestDate { get; set; }
    public int MaxPlayer { get; set; }
    public string? Policy { get; set; }
    public ContestStatusEnum ContestStatus { get; set; }

    public ICollection<UserContest> UserContests = new List<UserContest>();
    
    public Reservation? Reservation { get; set; }

}