using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Application.Services.Token;
using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests.Account;

namespace ShuttleZone.Application.Services.Account;

[AutoRegister]
public class AccountService : IAccountService
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<User> _signInManager;
    public AccountService(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
    }
    
    public async Task<NewAccountDto?> Register(RegisterDto registerDto)
    {
        var appUser = new User
        {
            UserName = registerDto.Username,
            Email = registerDto.Email,
            PhoneNumber = registerDto.PhoneNumber,
            Fullname = registerDto.Fullname,
            Gender = 0,
            
        };

        var result = await _userManager.CreateAsync(appUser, registerDto.Password);
        if (!result.Succeeded)
        {
            throw new Exception("Register failed!");
        }

        var roleResult = await _userManager.AddToRoleAsync(appUser, "Customer");
       
        if (roleResult.Succeeded)
        {
            var createdAccount =  new NewAccountDto
            {
                Id = appUser.Id,
                Username = appUser.UserName,
                Email = appUser.Email,
                Fullname = appUser.Fullname,
                Token = _tokenService.CreateToken(appUser)
            };
            return createdAccount;
        }
        else
        {
                await _userManager.DeleteAsync(appUser);
            throw new Exception("Register role failed!");
        }
    }

    public async Task<NewAccountDto> Login(LoginDto loginDto)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Account!.ToLower() || u.UserName == loginDto.Account.ToLower());
        if (user == null)
        {
           throw new Exception("User not found!");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false );

        if (!result.Succeeded)
            throw new Exception("Unauthorized");

        var loginAcc = new NewAccountDto
        {
            Id = user.Id,
            Username = user.UserName,
            Fullname = user.Fullname,
            Email = user.Email,
            Token = _tokenService.CreateToken(user)
        };

        return loginAcc;

    }
}
