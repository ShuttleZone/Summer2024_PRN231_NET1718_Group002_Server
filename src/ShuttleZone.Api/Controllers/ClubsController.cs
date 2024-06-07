using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Services;
using ShuttleZone.Application.Services.ReservationDetail;
using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.WebResponses;


namespace ShuttleZone.Api.Controllers;

/// <summary>
/// Handles HTTP request for club-related operations.
/// </summary>
public class ClubsController : BaseApiController
{
    private readonly IClubService _clubService;
    private readonly IReservationDetailService _reservationDetailService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ClubsController"/> class.
    /// </summary>
    /// <param name="clubService">The service for club management.</param>
    public ClubsController(IClubService clubService, IReservationDetailService reservationDetailService)
    {
        _clubService = clubService;
        _reservationDetailService = reservationDetailService;
    }

    /// <summary>
    /// Gets a list of clubs.
    /// </summary>
    /// <returns>A list of clubs.</returns>
    [EnableQuery]
    public ActionResult<IQueryable<DtoClubResponse>> Get()
    {
        var clubs = _clubService.GetClubs();
        return Ok(clubs);
    }

    /// <summary>
    /// Gets a club by its unique identifier.
    /// </summary>
    /// <returns>A club.</returns>
    [EnableQuery]
    public ActionResult<DtoClubResponse> Get([FromRoute] Guid key)
    {
        var club = _clubService.GetClub(key);
        if (club is null)
            return NotFound();

        return Ok(club);
    }
    
    [EnableQuery]
    [HttpGet("Clubs({key:Guid})/reservations-details")]
    public ActionResult<DtoClubResponse> GetReservation([FromRoute]Guid key)
    {
        var reservationDetail = _reservationDetailService.GetClubReservationDetails(key);
        return Ok(reservationDetail);
    }

    // public ActionResult Put([FromRoute] Guid key, [FromBody] AcceptClubRequestDto dto)
    // {
    //     var club = _clubService.AcceptClubRequest(key);
    //
    //     if (club != null)
    //     {
    //         club.ClubStatusEnum = dto.ClubStatusEnum;
    //     }
    //
    //     return Updated(club);
    // }
}
