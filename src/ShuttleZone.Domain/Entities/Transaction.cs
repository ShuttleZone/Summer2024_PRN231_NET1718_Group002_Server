using ShuttleZone.Common.Constants;
using ShuttleZone.Domain.Common;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities;

public class Transaction : BaseAuditableEntity<Guid>
{
    public PaymentMethod PaymentMethod { get; set; }
    public double Amount { get; set; }
    public TransactionStatusEnum TransactionStatus { get; set; } = TransactionStatusEnum.SUCCESS;
    public Guid? ReservationId { get; set; }
    public Reservation? Reservation { get; set; } 
    //tick
    public string TxnRef { get; set; } = String.Empty;
    public string TransactionNo { get; set; } = String.Empty;
    //paydate
    public string TransactionDate { get; set; } = String.Empty;
   // public string vnp_IpAddr { get; set; } = String.Empty;
  
}
