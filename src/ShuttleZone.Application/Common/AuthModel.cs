namespace ShuttleZone.Application.DependencyInjection.Common;

public class AuthModel
{
    public Guid UserId { get; set; }
    public required string UserName { get; set; }
    public required string Role { get; set; }
}