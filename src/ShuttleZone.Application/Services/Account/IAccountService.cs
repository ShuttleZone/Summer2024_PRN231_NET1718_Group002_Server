using ShuttleZone.Domain.WebRequests.Account;

namespace ShuttleZone.Application.Services.Account;

public interface IAccountService
{ 
    Task<RegisterDto> Register(RegisterDto registerDto);
}
