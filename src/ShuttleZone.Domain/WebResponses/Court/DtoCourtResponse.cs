using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.WebResponses.Court;

public class DtoCourtResponse
{
    public string? Name { get; set; }
    public CourtType CourtType { get; set; }
    public CourtStatus CourtStatus { get; set; }
    public required Guid ClubId { get; set; }
    public required string ClubName { get; set; }
}