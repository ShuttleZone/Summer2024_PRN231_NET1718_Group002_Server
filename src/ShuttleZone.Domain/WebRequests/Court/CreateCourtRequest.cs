using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.WebRequests;

public class CreateCourtRequest
{
    public Guid ClubId { get; set; }
    public required string Name { get; set; }
    public CourtType CourtType { get; set; }
    public CourtStatus CourtStatus { get; set; }
    public double Price { get; set; }
}
