using ShuttleZone.Domain.Common;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities;

public class Contest : BaseAuditableEntity<Contest>
{
    public Guid ContestId { get; set; }
    public DateTime ContestDate { get; set; }
    public int MaxPlayer { get; set; }
    public string? Policy { get; set; }
    public ContestStatusEnum ContestStatus { get; set; }

}