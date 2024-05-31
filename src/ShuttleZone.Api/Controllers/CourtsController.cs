using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Services.Court;

namespace ShuttleZone.Api.Controllers;

public sealed class CourtsController : BaseApiController
{
    private readonly ICourtService _courtService;

    public CourtsController(ICourtService courtService)
    {
        _courtService = courtService;
    }

    [EnableQuery]
    public IActionResult Get()
    {
        var courts = _courtService.GetAllCourts();
        return Ok(courts);
    }
}
