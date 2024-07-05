using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Application.Services;
using ShuttleZone.Domain.Constants;
using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebRequests.Contest;
using ShuttleZone.Domain.WebResponses.Contest;

namespace ShuttleZone.Api.Controllers;

public class ContestsController : BaseApiController
{
    private readonly IContestService _contestService;
    private readonly IUser _user;

    public ContestsController(IContestService contestService, IUser user)
    {
        _contestService = contestService;
        _user = user;
    }

    [EnableQuery]
    [Authorize]
    public ActionResult<IQueryable<DtoContestResponse>> Get()
    {
        var contests = _contestService.GetContests();
        return Ok(contests);
    }

    [EnableQuery]
    public ActionResult<DtoContestResponse> Get([FromRoute] Guid key)
    {
        var contest = _contestService.GetContestByContestId(key);
        return Ok(contest);
    }

    // [Authorize(Roles = SystemRole.Manager)]
    [HttpGet("/api/Contests/get-my-contests")]
    public IActionResult GetMyContests()
    {
        var userId = new Guid(_user.Id?? throw new ArgumentNullException());
        var result = _contestService.GetMyContest(userId);
        return Ok(result);
    }

    [Authorize(Roles = SystemRole.Manager)]
    [EnableQuery]
    [HttpGet("/api/Contests/my-club-contests({key:guid})")]
    public IActionResult GetMyClubContests([FromRoute] Guid key)
    {
        return HandleResult(() => _contestService.GetMyClubContests(key));
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

    [Authorize]
    public async Task<IActionResult> Put([FromRoute] Guid key, [FromBody] UpdateContestRequest? request = null)
    {
        return await HandleResultAsync(
            async () =>
            {
                if (request == null)
                {
                    await _contestService.JoinContest(key, UserId).ConfigureAwait(false);
                }
                else
                {
                    await _contestService.UpdateContestAsync(request).ConfigureAwait(false);
                }
            }
        ).ConfigureAwait(false);
    }
}
