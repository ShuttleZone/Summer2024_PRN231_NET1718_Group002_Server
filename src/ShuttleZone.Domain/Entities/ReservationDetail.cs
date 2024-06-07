using ShuttleZone.Domain.Common;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities;

public class ReservationDetail : BaseEntity<int>
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public double Price { get; set; }
    public ReservationStatusEnum ReservationDetailStatus { get; set; } = ReservationStatusEnum.PENDING;
    
    public Guid? CourtId { get; set; }
    public Court Court { get; set; } = null!;
    
    public Guid ReservationId { get; set; } 
    public  Reservation Reservation { get; set; } = null!;
}

