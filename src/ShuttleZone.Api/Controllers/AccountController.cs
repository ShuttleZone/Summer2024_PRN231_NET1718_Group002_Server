using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Services.Account;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.WebRequests.Account;

namespace ShuttleZone.Api.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController : BaseApiController
{
    private readonly IAccountService _accountService;
    private readonly UserManager<User> _userManager;
    public AccountController(IAccountService accountService, UserManager<User> userManager)
    {
        _accountService = accountService;
        _userManager = userManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        try
        {
            var checkEmail = await _userManager.FindByEmailAsync(registerDto.Email);
            if (checkEmail != null)
                return BadRequest("Email is used !");
            var checkUsername = await _userManager.FindByNameAsync(registerDto.Username);
            if (checkUsername != null)
                return BadRequest("Username is used !");
            var createdUser = await _accountService.Register(registerDto);
            if (createdUser != null && createdUser.Token != null)
            {
                SetCookiesToken(createdUser.Token);
                return Ok(createdUser);
                
            }
            else
            {
                return BadRequest("Error in register !");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        return Ok(await _accountService.Login(loginDto));
    }

    private void SetCookiesToken(string token)
    {
        HttpContext.Response.Cookies.Append("token",token);
    }
}