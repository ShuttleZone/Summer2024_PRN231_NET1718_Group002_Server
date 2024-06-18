using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Services.Court;
using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebResponses.Court;

namespace ShuttleZone.Api.Controllers;

public sealed class CourtsController : BaseApiController
{
    private readonly ICourtService _courtService;

    public CourtsController(ICourtService courtService)
    {
        _courtService = courtService;
    }

    [EnableQuery]
    public IQueryable<DtoCourtResponse> Get()
    {
        var courts = _courtService.GetAllCourts();
        return courts;
    }
    
    [EnableQuery]
    public DtoCourtResponse Get([FromRoute] Guid key)
    {
        var court =  _courtService.GetCourtById(key);
        return court;
    }

    public async Task<IActionResult> Post([FromForm] CreateCourtRequest request, CancellationToken cancellationToken)
    {
        return await HandleResultAsync(
            async () => await _courtService.CreateCourtAsync(request, cancellationToken).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }

    [HttpPut("/api/Courts/disableCourt/{courtId}")]
    public IActionResult DisableCourt([FromRoute] Guid courtId)
    {
        return Ok( _courtService.DisableCourt(courtId));
    }

    [HttpPut("/api/Courts/maintain/{courtId}")]
    public IActionResult MaintainCourt([FromRoute] Guid courtId)
    {
        return HandleResult(() => _courtService.MaintainCourt(courtId));
    }
}
