using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests.Account;

namespace ShuttleZone.Application.Services.Account;

public class AccountService : IAccountService
{
    private readonly UserManager<User> _userManager;
    public AccountService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<RegisterDto> Register(RegisterDto registerDto)
    {
        // try {
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);
        //    
        //
        //     };
        var appUser = new User
        {
            UserName = registerDto.Username,
            Email = registerDto.Email,
            Fullname = "Test",
            Gender = 0,
        };

            var createUser = await _userManager.CreateAsync(appUser, registerDto.Password!);
            if (createUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(appUser, "Customer");
                if (roleResult.Succeeded)
                {
                    return registerDto;
                }
                else
                {
                    throw new Exception();
                }
            }
            else
            {
                throw new Exception();
            }
    }
    
}