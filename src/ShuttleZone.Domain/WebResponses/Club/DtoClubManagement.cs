namespace ShuttleZone.Domain.WebResponses.Club;

public class DtoClubManagement
{
    public Guid Id { get; set; }
    public required string ClubName { get; set; }
    public required string ClubAddress { get; set; }
    public required string OpenHour { get; set; }
    public double Rating { get; set; } = default;
    public int TotalCourt { get; set; } = default;
    public int TotalReview { get; set; } = default;
}