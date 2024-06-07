using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Application.Services.Token;

[AutoRegister]
public interface ITokenService
{
    string CreateToken(User user);

    object? GetTokenClaim(string token, string claimName);

    AuthModel GetAuthModel(string token);
}

public record AuthModel
{
    public Guid UserId { get; set; }
    public required string UserName { get; set; }
    public required string Role { get; set; }
}

