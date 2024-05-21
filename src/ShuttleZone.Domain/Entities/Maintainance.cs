using ShuttleZone.Domain.Common;

namespace ShuttleZone.Domain.Entities;

public class Maintenance : BaseAuditableEntity<Maintenance>
{
    public Guid MaintenanceId { get; set; }
    public string? Reason { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    
}