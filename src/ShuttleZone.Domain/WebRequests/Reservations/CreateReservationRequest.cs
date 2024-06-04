using ShuttleZone.Domain.WebRequests.ReservationDetails;
using ShuttleZone.Domain.WebRequests.Transactions;

namespace ShuttleZone.Domain.WebRequests.Reservations
{
    public class CreateReservationRequest
    {        
        public double TotalPrice { get; set; }       
        public string? Note { get; set; }
        public Guid CustomerId { get; set; }    
        public ICollection<CreateReservationDetailRequest>? ReservationDetails { get; set; } 
        public ICollection<CreateTransactionRequest>? Transactions { get; set; }
        public Guid? ContestId { get; set; }       
    }
}
