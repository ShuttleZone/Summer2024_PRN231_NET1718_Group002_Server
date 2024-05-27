using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Application.Services.Court;

namespace ShuttleZone.Api.Controllers;
[Route("/api/[controller]")]
public class CourtController : ControllerBase
{
    private readonly ICourtService _courtService;

    public CourtController(ICourtService courtService)
    {
        _courtService = courtService;
    }
    [EnableQuery]
    [HttpGet]
    public IActionResult GetAllCourts()
    {
        var courts = _courtService.GetAllCourts();
        return Ok(courts);
    }
    
    
}