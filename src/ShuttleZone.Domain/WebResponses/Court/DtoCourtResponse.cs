using ShuttleZone.Domain.Enums;

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
    public ICollection<DtoReservationDetail> ReservationDetails { get; set; } = new List<DtoReservationDetail>();
}

public record DtoReservationDetail
{
    public int Id { get; set; }
    public string CourtName { get; set; } = null!;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime Date { get; set; }
}