using ShuttleZone.Domain.Common;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities;

public class Court : BaseAuditableEntity<Guid>
{
    public string? Name { get; set; }
    public CourtType CourtType { get; set; }
    public CourtStatus CourtStatus { get; set; }
    public double Price { get; set; }
    
    public required Guid ClubId { get; set; }
    public Club Club { get; set; } = null!;

    public ICollection<Maintenance> Maintenances = new List<Maintenance>();
    public ICollection<ReservationDetail> ReservationDetails = new List<ReservationDetail>();
}
