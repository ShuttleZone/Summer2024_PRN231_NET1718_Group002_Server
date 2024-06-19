using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Application.Services.ShuttleZoneUser;
using ShuttleZone.Domain.WebRequests.ShuttleZoneUser;

namespace ShuttleZone.Api.Controllers;
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UsersController : BaseApiController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("/api/profile")]
    [EnableQuery]
    public IActionResult GetProfile()
    {
        return HandleResult(() => _userService.GetUserProfileInformation() );
    }

    [HttpPut("/api/profile")]
    public IActionResult UpdateProfile([FromBody]UpdateProfileRequest request)
    {
        return HandleResult((() => _userService.UpdateUserProfile(request)));
    }
    
}