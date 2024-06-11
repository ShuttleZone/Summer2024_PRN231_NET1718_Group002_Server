using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Services;
using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebResponses.Contest;

namespace ShuttleZone.Api.Controllers;

public class ContestsController : BaseApiController
{
    private readonly IContestService _contestService;

    public ContestsController(IContestService contestService)
    {
        _contestService = contestService;
    }
    
    [EnableQuery]
    [Authorize]
    public ActionResult<IQueryable<DtoContestResponse>> Get()
    {
        var contests = _contestService.GetContests();
        return Ok(contests);
    }

    [EnableQuery]
    public ActionResult<DtoContestResponse> Get([FromRoute]Guid key)
    {
        var contest = _contestService.GetContestByContestId(key);
        return Ok(contest);
    }
    
    // [EnableQuery]
    // public ActionResult<Contest> Get([FromRoute]Guid key)
    // {
    //     var contest = _contestService.GetContestDetail(key);
    //     return Ok(contest);
    // }

    [Authorize]
    public async Task<IActionResult> Post([FromBody] CreateContestRequest request, CancellationToken cancellationToken = default)
    {
        return await HandleResultAsync(
            async () => await _contestService.CreateContestAsync(request, cancellationToken).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }
}
