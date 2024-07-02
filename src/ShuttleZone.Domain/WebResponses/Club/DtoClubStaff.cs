namespace ShuttleZone.Domain.WebResponses.Club;

public record DtoClubStaff : DtoStaffProfile
{
    public required string ClubName { get; set; }
    public required string ClubAddress { get; set; }
    public Guid ClubId { get; set; }
}