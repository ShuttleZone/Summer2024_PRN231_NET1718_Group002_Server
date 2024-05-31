using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ShuttleZone.Application.Services;
using ShuttleZone.Domain.WebResponses.Contest;

namespace ShuttleZone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ContestsController : ODataController
{
    private readonly IContestService _contestService;

    public ContestsController(IContestService contestService)
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

    [EnableQuery]
    [HttpGet("/GetContestByUserId/{userId}")]
    public ActionResult<IQueryable<DtoMyContestResponse>> GetMyContest(Guid userId)
    {
        var contest = _contestService.GetContestByUserId(userId);
        return Ok(contest);
    }

}
