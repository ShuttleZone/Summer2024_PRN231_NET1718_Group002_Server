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

    public ActionResult Post([FromBody] CreateCourtRequest createCourtRequest)
    {
        // var court =  _courtService.GetCourtById(key);
        Console.WriteLine(createCourtRequest);
        // if (createCourtRequest == null)
        // {
        //     return BadRequest();
        // }

        return Created(
            new CreateCourtRequest()
            {
                Name = "",
                ClubId = Guid.NewGuid(),
                CourtType = Domain.Enums.CourtType.Date,
                CourtStatus = Domain.Enums.CourtStatus.Available,
                Price = 0.0
            }
        );
    }
}
