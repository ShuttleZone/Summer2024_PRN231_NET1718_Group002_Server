namespace ShuttleZone.Domain.WebRequests.ReservationDetails
{
    public class CreateReservationDetailRequest
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Price { get; set; }
        public Guid? CourtId { get; set; }    
    }
}
