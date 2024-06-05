using System.ComponentModel.DataAnnotations;

namespace ShuttleZone.Domain.WebRequests.ReservationDetails
{
    public class CreateReservationDetailRequest
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public double Price { get; set; }
        [Required]
        public Guid CourtId { get; set; } 
    }
}
