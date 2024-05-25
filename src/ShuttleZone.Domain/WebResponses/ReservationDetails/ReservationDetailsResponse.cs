using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.WebResponses.ReservationDetails
{
    public class ReservationDetailsResponse
    {
        public Guid Id { get; set; }
        public string? CourtName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Price { get; set; }
        public ReservationStatusEnum ReservationDetailStatus { get; set; }
    }
}
