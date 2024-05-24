using System.ComponentModel.DataAnnotations;
using ShuttleZone.Domain.Common;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities;

public class Court : BaseAuditableEntity<Guid>
{
    public string? Name { get; set; }
    public CourtType CourtType { get; set; }
    public CourtStatus CourtStatus { get; set; }
    
    public required Guid ClubId { get; set; }
    public Club? Club { get; set; }//require

    public ICollection<Maintenance> Maintenances = new List<Maintenance>();
    public ICollection<ReservationDetail> ReservationDetails = new List<ReservationDetail>();
}