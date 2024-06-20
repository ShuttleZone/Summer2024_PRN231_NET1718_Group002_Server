using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Application.Services.Email;
using ShuttleZone.Application.Services.Token;
using ShuttleZone.Common.Attributes;
using ShuttleZone.Common.Exceptions;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebRequests.Account;

namespace ShuttleZone.Application.Services.Account;

[AutoRegister]
public class AccountService : IAccountService
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<User> _signInManager;
    private readonly IUser _currentUser;
    private readonly IEmailService _emailService;

    public AccountService(UserManager<User> userManager, 
        ITokenService tokenService, 
        SignInManager<User> signInManager, 
        IUser currentUser,
        IEmailService emailService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
        _currentUser = currentUser;
        _emailService = emailService;
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
            throw new Exception(result.Errors.First().Description);
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
            /// <summary>
            /// nhi: 21/6/2024 confirm email.
            /// </summary>
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            await _emailService.SendEmailConfirmationAsync(appUser, token);

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

    public async Task ChangePasswordAsync(ChangePasswordRequest request, CancellationToken cancellationToken)
    {
        HttpException.New()
            .WithStatusCode(401)
            .WithErrorMessage("Unauthorized")
            .ThrowIfNull(_currentUser.Id);

        var user = await _userManager.FindByIdAsync(_currentUser.Id.ToString());

        HttpException.New()
            .WithStatusCode(404)
            .WithErrorMessage("User not found!")
            .ThrowIfNull(user);

        var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

        HttpException.New()
            .WithStatusCode(400)
            .WithErrorMessage(result.Errors.FirstOrDefault()?.Description ?? "An error occurred while processing your request")
            .ThrowIf(!result.Succeeded);
    }

    public async Task ConfirmEmailAsync(string userId, string token)
    {
        if (userId == null || token == null)
            throw new HttpException(400, "Invalid token");

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            throw new HttpException(400, "User not found");

        var result = await _userManager.ConfirmEmailAsync(user, token);

        if (!result.Succeeded)
            throw new HttpException(400, result.Errors.First().Description);
       
    }
}
