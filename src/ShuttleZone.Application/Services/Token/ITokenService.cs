using ShuttleZone.Application.DependencyInjection.Common;
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