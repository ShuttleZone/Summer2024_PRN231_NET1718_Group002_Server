namespace ShuttleZone.Domain.WebResponses;

public record DtoClubResponse
{
    public required string ClubName { get; set; }
    public required string ClubAddress { get; set; }
    public required string ClubPhone { get; set; }
    public required string ClubDescription { get; set; }
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }
}
