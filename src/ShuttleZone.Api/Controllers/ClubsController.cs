using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Services;
using ShuttleZone.Domain.WebResponses;
using ShuttleZone.Domain.WebResponses.Club;


namespace ShuttleZone.Api.Controllers;

/// <summary>
/// Handles HTTP request for club-related operations.
/// </summary>
public class ClubsController : BaseApiController
{
    private readonly IClubService _clubService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ClubsController"/> class.
    /// </summary>
    /// <param name="clubService">The service for club management.</param>
    public ClubsController(IClubService clubService)
    {
        _clubService = clubService;
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
   
}
