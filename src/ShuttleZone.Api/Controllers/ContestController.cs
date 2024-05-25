using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Application.Services;
using ShuttleZone.Domain.WebResponses.Contest;

namespace ShuttleZone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ContestController : ControllerBase
{
    private readonly IContestService _contestService;

    public ContestController(IContestService contestService)
    {
        _contestService = contestService;
    }
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [EnableQuery]
    [HttpGet]
    public ActionResult<IQueryable<DtoContestResponse>> GetContests()
    {
        var contests = _contestService.GetContests();
        return Ok(contests);
    }

}