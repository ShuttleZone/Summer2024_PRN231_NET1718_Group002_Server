using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Services.Account;
using ShuttleZone.Application.Services.Email;
using ShuttleZone.Application.Services.Token;
using ShuttleZone.Domain.Constants;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebRequests.Account;

namespace ShuttleZone.Api.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController : BaseApiController
{
    private readonly IAccountService _accountService;
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly IEmailService _emailService;

    public AccountController(IAccountService accountService,
        UserManager<User> userManager,
        ITokenService tokenService,
        SignInManager<User> signInManager,
        IEmailService emailService,
        IConfiguration configuration)
    {
        _accountService = accountService;
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
        _configuration = configuration;
        _emailService = emailService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            // // Check model state validity
            // if (!ModelState.IsValid)
            // {
            //     return BadRequest(ModelState.First());
            // }

            // Check if the user with the provided email or username already exists
            var existingUserByEmail = await _userManager.FindByEmailAsync(registerDto.Email);
            var existingUserByUsername = await _userManager.FindByNameAsync(registerDto.Username);

            if (existingUserByEmail != null)
            {
                return StatusCode(500, $"Người dùng với email: {existingUserByEmail.Email} đã tồn tại!");
            }

            if (existingUserByUsername != null)
            {
                return StatusCode(500, $"Người dùng với tài khoản: {existingUserByUsername.UserName} đã tồn tại!");
            }

            var appUser = new User
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
                Fullname = registerDto.Fullname,
                Gender = 0,
            };

            // Attempt to create the user with the provided password
            var creationResult = await _userManager.CreateAsync(appUser, registerDto.Password);
            if (!creationResult.Succeeded)
            {
                return StatusCode(500, creationResult.Errors.Select(e => e.Description));
            }

            // Attempt to assign the user to the "Customer" role
            var roleAssignmentResult = await _userManager.AddToRoleAsync(appUser, "Customer");
            if (!roleAssignmentResult.Succeeded)
            {
                // Rollback user creation if role assignment fails
                await _userManager.DeleteAsync(appUser);
                return StatusCode(500, roleAssignmentResult.Errors.Select(e => e.Description));
            }

            // Prepare the new account data
            var createdAccount = new NewAccountDto
            {
                Id = appUser.Id,
                Username = appUser.UserName,
                Email = appUser.Email,
                Fullname = appUser.Fullname,
                Token = _tokenService.CreateToken(appUser),
                RefreshToken = ""
            };

            // Set the token in cookies
            // SetCookiesToken(createdAccount.Token);

            /// <summary>
            /// nhi: 21/6/2024 confirm email.
            /// </summary>
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            #pragma warning disable
            _emailService.SendEmailConfirmationAsync(appUser, token);


            // Return success response with the token
            return Ok($"User created");

        }
        catch (Exception ex)
        {
            // Return a 500 status code with a generic error message
            return StatusCode(500, "An error occurred while processing your request:" + ex);
        }
    }
    
    [HttpPost("registerManager")]
    public async Task<IActionResult> RegisterManager([FromBody] RegisterDto registerDto)
    {
        try
        {
            // // Check model state validity
            // if (!ModelState.IsValid)
            // {
            //     return BadRequest(ModelState.First());
            // }

            // Check if the user with the provided email or username already exists
            var existingUserByEmail = await _userManager.FindByEmailAsync(registerDto.Email);
            var existingUserByUsername = await _userManager.FindByNameAsync(registerDto.Username);

            if (existingUserByEmail != null)
            {
                return StatusCode(500, $"Người dùng với email: {existingUserByEmail.Email} đã tồn tại!");
            }

            if (existingUserByUsername != null)
            {
                return StatusCode(500, $"Người dùng với tài khoản: {existingUserByUsername.UserName} đã tồn tại!");
            }

            var appUser = new User
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
                Fullname = registerDto.Fullname,
                Gender = 0,
            };

            // Attempt to create the user with the provided password
            var creationResult = await _userManager.CreateAsync(appUser, registerDto.Password);
            if (!creationResult.Succeeded)
            {
                return StatusCode(500, creationResult.Errors.Select(e => e.Description));
            }

            // Attempt to assign the user to the "Customer" role
            var roleAssignmentResult = await _userManager.AddToRoleAsync(appUser, SystemRole.Manager);
            if (!roleAssignmentResult.Succeeded)
            {
                // Rollback user creation if role assignment fails
                await _userManager.DeleteAsync(appUser);
                return StatusCode(500, roleAssignmentResult.Errors.Select(e => e.Description));
            }

            // Prepare the new account data
            var createdAccount = new NewAccountDto
            {
                Id = appUser.Id,
                Username = appUser.UserName,
                Email = appUser.Email,
                Fullname = appUser.Fullname,
                Token = _tokenService.CreateToken(appUser),
                RefreshToken = ""
            };

            // Set the token in cookies
            // SetCookiesToken(createdAccount.Token);

            /// <summary>
            /// nhi: 21/6/2024 confirm email.
            /// </summary>
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            #pragma warning disable
            _emailService.SendEmailConfirmationAsync(appUser, token);


            // Return success response with the token
            return Ok($"Manager created");

        }
        catch (Exception ex)
        {
            // Return a 500 status code with a generic error message
            return StatusCode(500, "An error occurred while processing your request:" + ex);
        }
    }

     [HttpPost("registerStaff")]
    public async Task<IActionResult> RegisterStaff([FromBody] RegisterDto registerDto)
    {
        try
        {
            // // Check model state validity
            // if (!ModelState.IsValid)
            // {
            //     return BadRequest(ModelState.First());
            // }

            // Check if the user with the provided email or username already exists
            var existingUserByEmail = await _userManager.FindByEmailAsync(registerDto.Email);
            var existingUserByUsername = await _userManager.FindByNameAsync(registerDto.Username);

            if (existingUserByEmail != null)
            {
                return StatusCode(500, $"Người dùng với email: {existingUserByEmail.Email} đã tồn tại!");
            }

            if (existingUserByUsername != null)
            {
                return StatusCode(500, $"Người dùng với tài khoản: {existingUserByUsername.UserName} đã tồn tại!");
            }

            var appUser = new User
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
                PhoneNumber = registerDto.PhoneNumber,
                Fullname = registerDto.Fullname,
                Gender = 0,
            };

            // Attempt to create the user with the provided password
            var creationResult = await _userManager.CreateAsync(appUser, registerDto.Password);
            if (!creationResult.Succeeded)
            {
                return StatusCode(500, creationResult.Errors.Select(e => e.Description));
            }

            // Attempt to assign the user to the "Customer" role
            var roleAssignmentResult = await _userManager.AddToRoleAsync(appUser, SystemRole.Staff);
            if (!roleAssignmentResult.Succeeded)
            {
                // Rollback user creation if role assignment fails
                await _userManager.DeleteAsync(appUser);
                return StatusCode(500, roleAssignmentResult.Errors.Select(e => e.Description));
            }

            // Prepare the new account data
            var createdAccount = new NewAccountDto
            {
                Id = appUser.Id,
                Username = appUser.UserName,
                Email = appUser.Email,
                Fullname = appUser.Fullname,
                Token = _tokenService.CreateToken(appUser),
                RefreshToken = ""
            };

            // Set the token in cookies
            // SetCookiesToken(createdAccount.Token);

            /// <summary>
            /// nhi: 21/6/2024 confirm email.
            /// </summary>
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            #pragma warning disable
            _emailService.SendEmailConfirmationAsync(appUser, token);


            // Return success response with the token
            return Ok($"Manager created");

        }
        catch (Exception ex)
        {
            // Return a 500 status code with a generic error message
            return StatusCode(500, "An error occurred while processing your request:" + ex);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Account!.ToLower() || u.UserName == loginDto.Account.ToLower());
        if (user == null)
            return StatusCode(400, "Người dùng với tài khoản: " + loginDto.Account + " không tồn tại!");
        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
        if (!result.Succeeded)
            return Unauthorized("Sai mật khẩu! Xin hãy thử lại");

        var refreshToken = _tokenService.CreateRefreshToken();
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(15);

        await _userManager.UpdateAsync(user);

        var loginAcc = new NewAccountDto
        {
            Id = user.Id,
            Username = user.UserName,
            Fullname = user.Fullname,
            Email = user.Email,
            Token = _tokenService.CreateToken(user),
            RefreshToken = refreshToken
        };
        return Ok(loginAcc);
    }

    [Authorize]
    [HttpPatch("password")]
    public async Task<IActionResult> ChangePassword(ChangePasswordRequest request, CancellationToken cancellationToken)
    {
        return await HandleResultAsync(
            async () => await _accountService.ChangePasswordAsync(request, cancellationToken).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }

    [HttpGet("/confirm-email")]
    public async Task<IActionResult> ConfirmEmail(string userId, string token)
    {
        return await HandleResultAsync(
            async () => await _accountService.ConfirmEmailAsync(userId, token).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshModel refreshModel)
    {
        var principal = GetPrincipalFromExpiredToken(refreshModel.AccessToken);
        if (principal?.Identity!.Name is null)
        {
            return Unauthorized();
        }

        var user = await _userManager.FindByNameAsync(principal.Identity.Name);

        if (user is null || user.RefreshToken != refreshModel.RefreshToken ||
            user.RefreshTokenExpiryTime < DateTime.UtcNow)
            return Unauthorized();
        var token = _tokenService.CreateToken(user);
        var loginAcc = new NewAccountDto
        {
            Id = user.Id,
            Username = user.UserName,
            Fullname = user.Fullname,
            Email = user.Email,
            Token = token,
            RefreshToken = refreshModel.RefreshToken
        };
        return Ok(loginAcc.Token);
    }

    [HttpDelete("revoke")]
    public async Task<IActionResult> Revoke()
    {
        var username = HttpContext.User?.Identity?.Name;

        if (username is null)
            return Unauthorized();
        var user = await _userManager.FindByNameAsync(username);
        if (user is null)
            return Unauthorized();
        user.RefreshToken = null;
        await _userManager.UpdateAsync(user);
        return Ok();
    }

    private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
    {
        var validation = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]!)),
            ValidateLifetime = false
        };

        return new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);
    }

}
