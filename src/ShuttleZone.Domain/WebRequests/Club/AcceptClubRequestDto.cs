using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.WebRequests;

public class AcceptClubRequestDto
{
    public ClubStatusEnum ClubStatusEnum { get; set; }
}