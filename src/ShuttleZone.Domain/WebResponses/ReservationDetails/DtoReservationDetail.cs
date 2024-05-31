namespace ShuttleZone.Domain.WebResponses.ReservationDetails;

public class DtoReservationDetail
{
    public required string CourtName { get; set; } 
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime Date { get; set; }
}