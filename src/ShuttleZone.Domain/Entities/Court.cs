using ShuttleZone.Domain.Common;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities;

public class Court 
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public CourtType CourtType { get; set; }
    public CourtStatus CourtStatus { get; set; }
    public double Price { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public string? CreatedBy { get; set; } = string.Empty;
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
    public required Guid ClubId { get; set; }
    public Club Club { get; set; } = null!;
    public ICollection<Maintenance> Maintenances = new List<Maintenance>();
    public ICollection<ReservationDetail> ReservationDetails = new List<ReservationDetail>();
}
