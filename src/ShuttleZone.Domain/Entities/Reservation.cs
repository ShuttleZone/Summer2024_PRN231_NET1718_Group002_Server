using ShuttleZone.Domain.Common;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities;

public class Reservation : BaseAuditableEntity<Guid>
{
    public DateTime BookingDate { get; set; } = DateTime.UtcNow;    
    public double TotalPrice { get; set; }
    public ReservationStatusEnum ReservationStatusEnum { get; set; } = ReservationStatusEnum.VALID;
    public string? Note { get; set; }
    
    public Guid CustomerId { get; set; }
    public User? Customer { get; set; }

    public ICollection<ReservationDetail> ReservationDetails = new List<ReservationDetail>();
    public ICollection<Transaction> Transactions = new List<Transaction>();
    
    public Guid? ContestId { get; set; }
    public Contest? Contest { get; set; }
}
