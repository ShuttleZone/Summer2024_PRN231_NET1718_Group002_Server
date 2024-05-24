using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Application.Services;
using ShuttleZone.Domain.WebResponses;

namespace ShuttleZone.Api.Controllers;

/// <summary>
/// Handles HTTP request for club-related operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public sealed class ClubsController : ControllerBase
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
    /// <response code="200">Returns the list of clubs.</response>
    /// <response code="400">If the request is invalid.</response>
    /// <response code="401">If the user is not authenticated.</response>
    /// <response code="403">If the user is not authorized.</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [EnableQuery]
    [HttpGet]
    public async Task<ActionResult<IQueryable<DtoClubResponse>>> GetClubs()
    {
        var clubs = await _clubService.GetClubsAsync();
        return Ok(clubs);
    }
}
