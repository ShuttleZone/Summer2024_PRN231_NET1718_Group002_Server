using System.ComponentModel.DataAnnotations;

namespace ShuttleZone.Domain.WebRequests.ShuttleZoneUser;

public class AssignStaffRequest
{
    public Guid ClubId { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string FullName { get; set; }
    public int Gender { get; set; }
    [Phone]
    public required string PhoneNumber { get; set; }
}