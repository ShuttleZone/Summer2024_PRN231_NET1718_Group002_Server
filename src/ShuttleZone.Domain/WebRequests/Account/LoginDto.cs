namespace ShuttleZone.Domain.WebRequests.Account;

public class LoginDto
{
    public required string Account { get; set; }
    public required string Password { get; set; }
    
}
