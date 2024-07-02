using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebRequests.Account;
using ShuttleZone.Domain.WebRequests.ShuttleZoneUser;

namespace ShuttleZone.Application.Services.Account;

public interface IAccountService
{ 
    Task<NewAccountDto?> Register(RegisterDto registerDto);

    Task<NewAccountDto> Login(LoginDto loginDto);

    Task ChangePasswordAsync(ChangePasswordRequest request, CancellationToken cancellationToken);
    Task ConfirmEmailAsync(string userId, string token);
    Task AssignStaff(AssignStaffRequest request);

}
