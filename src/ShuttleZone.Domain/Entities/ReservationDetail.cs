using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities;

public class ReservationDetail
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public double Price { get; set; }
    public ReservationStatusEnum ReservationDetailStatus { get; set; }
    
}