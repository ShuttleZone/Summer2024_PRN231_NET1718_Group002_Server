using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Application.Services.File;
using ShuttleZone.Application.Services.ShuttleZoneUser;
using ShuttleZone.Domain.WebRequests.ShuttleZoneUser;

namespace ShuttleZone.Api.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UsersController : BaseApiController
{
    private readonly IUserService _userService;
    private readonly IFileService _fileService;

    public UsersController(IUserService userService, IFileService fileService)
    {
        _userService = userService;
        _fileService = fileService;
    }

    [HttpGet("/api/profile")]
    [EnableQuery]
    public IActionResult GetProfile()
    {
        return HandleResult(() => _userService.GetUserProfileInformation());
    }

    [HttpPut("/api/profile")]
    public IActionResult UpdateProfile([FromBody] UpdateProfileRequest request)
    {
        return HandleResult((() => _userService.UpdateUserProfile(request)));
    }

    [HttpPost("/api/avatar-update")]
    public IActionResult UploadImage(IFormFile file)
    {
        return HandleResult(() => _userService.UploadNewAvatar(file));
    }

    [HttpPost("/test")]
    public IActionResult Test(IFormFile file)
    {
        return HandleResult(async () => await _fileService.UploadSingleFileAsync(file));
    }
}