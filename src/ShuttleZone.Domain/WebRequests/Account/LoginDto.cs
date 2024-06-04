namespace ShuttleZone.Domain.WebRequests.Account;

public class LoginDto
{
    public string? Account { get; set; }
    public required string Password { get; set; }
    
}