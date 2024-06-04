using ShuttleZone.Domain.Enums;
using ShuttleZone.Domain.WebResponses.ReservationDetails;

namespace ShuttleZone.Domain.WebResponses.Court;

public class DtoCourtResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public CourtType CourtType { get; set; }
    public CourtStatus CourtStatus { get; set; }
    public required Guid ClubId { get; set; }
    public required string ClubName { get; set; }
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }
    public double MinDuration { get; set; }
    public double Price { get; set; }
    public ICollection<DtoReservationDetail> ReservationDetails { get; set; } = new List<DtoReservationDetail>();
}

