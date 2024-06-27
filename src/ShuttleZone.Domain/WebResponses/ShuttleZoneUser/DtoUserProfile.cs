namespace ShuttleZone.Domain.WebResponses.ShuttleZoneUser;

public class DtoUserProfile
{
    public Guid Id { get; set; }
    public required string UserName { get; set; } 
    public required string Email { get; set; } 
    public required string Fullname { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ProfileImage { get; set; }
    public required int Gender { get; set; }
    public int TotalReservation { get; set; }
    public int TotalWinContest { get; set; }
    public decimal Balance { get; set; }
}