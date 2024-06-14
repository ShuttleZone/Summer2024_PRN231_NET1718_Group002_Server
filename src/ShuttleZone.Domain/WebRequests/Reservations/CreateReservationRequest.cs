using ShuttleZone.Domain.WebRequests.ReservationDetails;
using System.ComponentModel.DataAnnotations;

namespace ShuttleZone.Domain.WebRequests.Reservations
{
    public class CreateReservationRequest
    {
        [Range(5000, double.MaxValue, ErrorMessage = "TotalPrice must be greater than 5000.")]
        public double TotalPrice { get; set; }       
        public string? Note { get; set; }
        public string? Phone { get; set; }
        public string? FullName { get; set; }       
        public ICollection<CreateReservationDetailRequest>? ReservationDetails { get; set; }      
    }
}
