using ShuttleZone.Domain.Common;

namespace ShuttleZone.Domain.Entities;

public class Maintenance : BaseAuditableEntity<Guid>
{
    public required string Reason { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    
    public required Guid CourtId { get; set; }
    public required Court Court { get; set; }//require
}
