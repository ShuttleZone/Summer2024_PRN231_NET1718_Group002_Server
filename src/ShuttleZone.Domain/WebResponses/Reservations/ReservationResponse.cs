using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Domain.WebResponses.Reservations
{
    public class ReservationResponse
    {
        public Guid Id { get; set; } 
        public DateTime BookingDate { get; set; } 
        public double TotalPrice { get; set; }
        public string? ReservationStatusEnum { get; set; }    
        public ICollection<string>? CourtNames { get; set; }       
       
    }
}
