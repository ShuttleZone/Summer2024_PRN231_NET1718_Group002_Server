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
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
      return Ok(await _accountService.Register(registerDto));
    }
}