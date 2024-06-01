using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Services;
using ShuttleZone.Domain.Entities;
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
    public ActionResult<IQueryable<DtoContestResponse>> Get()
    {
        var contests = _contestService.GetContests();
        return Ok(contests);
    }

    // [EnableQuery]
    // public ActionResult<DtoContestResponse> Get([FromRoute]Guid key)
    // {
    //     var contest = _contestService.GetContestByUserId(key);
    //     return Ok(contest);
    // }
    
    [EnableQuery]
    public ActionResult<Contest> Get([FromRoute]Guid key)
    {
        var contest = _contestService.GetContestDetail(key);
        return Ok(contest);
    }

}
