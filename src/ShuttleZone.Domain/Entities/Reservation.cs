using ShuttleZone.Domain.Common;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities;

public class Reservation : BaseAuditableEntity<Guid>
{
    public DateTime BookingDate { get; set; } = DateTime.Now;    
    public DateTime ExpiredTime { get; set; } = DateTime.Now;    
    public double TotalPrice { get; set; }
    public ReservationStatusEnum ReservationStatusEnum { get; set; } = ReservationStatusEnum.PENDING;
    public string? Note { get; set; }
    public string? Phone { get; set; }
    public string? FullName { get; set; }
    
    public Guid? CustomerId { get; set; }
    public User? Customer { get; set; }

    public ICollection<ReservationDetail> ReservationDetails = new List<ReservationDetail>();
    public ICollection<Transaction> Transactions = new List<Transaction>();
    
    public Guid? ContestId { get; set; }
    public Contest? Contest { get; set; }
}
