using System.ComponentModel.DataAnnotations;
using ShuttleZone.Domain.Common;

namespace ShuttleZone.Domain.Entities;

public class Maintenance : BaseAuditableEntity<Maintenance>
{
    [Key]
    public Guid MaintenanceId { get; set; }
    public string? Reason { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    
    public required Guid CourtId { get; set; }
    public Court? Court { get; set; }
}