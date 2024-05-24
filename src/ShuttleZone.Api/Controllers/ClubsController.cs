using Microsoft.AspNetCore.Mvc;
using ShuttleZone.Application.Services.Club;

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
}
