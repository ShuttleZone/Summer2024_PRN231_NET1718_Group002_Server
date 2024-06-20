using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebRequests.Account;

namespace ShuttleZone.Application.Services.Account;

public interface IAccountService
{ 
    Task<NewAccountDto?> Register(RegisterDto registerDto);

    Task<NewAccountDto> Login(LoginDto loginDto);

    Task ChangePasswordAsync(ChangePasswordRequest request, CancellationToken cancellationToken);
    Task ConfirmEmailAsync(string userId, string token);
}
