namespace ShuttleZone.Domain.WebRequests.ShuttleZoneUser;

public class UpdateProfileRequest
{
    public string? FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public int Gender { get; set; }
}