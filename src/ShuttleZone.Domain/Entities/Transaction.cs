using ShuttleZone.Domain.Common;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities;

public class Transaction : BaseAuditableEntity<Guid>
{
    public PaymentMethod PaymentMethod { get; set; }
    public double Amount { get; set; }
    public TransactionStatusEnum TransactionStatus { get; set; }
    
    public Guid ReservationId { get; set; }
    public Reservation Reservation { get; set; } = null!;
}