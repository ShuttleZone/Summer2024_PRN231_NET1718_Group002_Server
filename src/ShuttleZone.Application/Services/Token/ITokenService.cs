using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Application.Services.Token;

[AutoRegister]
public interface ITokenService
{
    string CreateToken(User user);
}