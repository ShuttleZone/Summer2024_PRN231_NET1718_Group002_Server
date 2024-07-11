using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Application.Services;
using ShuttleZone.Application.Services.Account;
using ShuttleZone.Application.Services.ReservationDetail;
using ShuttleZone.Domain.WebRequests.Club;
using ShuttleZone.Domain.WebRequests.ShuttleZoneUser;
using ShuttleZone.Domain.WebResponses;
using SystemRole = ShuttleZone.Domain.Constants.SystemRole;


namespace ShuttleZone.Api.Controllers;

/// <summary>
/// Handles HTTP request for club-related operations.
/// </summary>
public class ClubsController : BaseApiController
{
    private readonly IClubService _clubService;
    private readonly IReservationDetailService _reservationDetailService;
    private readonly IAccountService _accountService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ClubsController"/> class.
    /// </summary>
    /// <param name="clubService">The service for club management.</param>
    public ClubsController(IClubService clubService, IReservationDetailService reservationDetailService, IAccountService accountService)
    {
        _clubService = clubService;
        _reservationDetailService = reservationDetailService;
        _accountService = accountService;
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
    // [Authorize(Roles = SystemRole.Manager)]
    public ActionResult<DtoClubResponse> GetReservation([FromRoute]Guid key)
    {
        var reservationDetail = _reservationDetailService.GetClubReservationDetails(key);
        return Ok(reservationDetail);
    }

    [EnableQuery]
    // [Authorize(Roles = SystemRole.Manager)]
    [Authorize]
    [HttpGet("/api/Clubs/my-clubs")]
    public IActionResult GetMyClubs()
    {
        return base.HandleResult(
            () => _clubService.GetMyClubs()
        );
    }

    public ActionResult Put([FromRoute] Guid key)
    {
        var club = _clubService.AcceptClubRequest(key);
        if (club == false)
            return NotFound();
        return Updated(club);
    }
    
    [HttpPut("/api/Clubs/rejectRequest/{key}")]
    public ActionResult RejectRequestPut([FromRoute] Guid key)
    {
        var club = _clubService.RejectClubRequest(key);
        if (club == false)
            return NotFound();
        return Updated(club);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm] CreateClubRequest request)
    {
        return await HandleResultAsync(
            async () => await _clubService.AddClubAsync(request).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }

    [HttpPut("/api/clubs/{key}/assign-staff")]
    public async Task<IActionResult> AssignStaff([FromRoute] Guid key, [FromBody] AssignStaffRequest request)
    {
        request.ClubId = key;
        return await HandleResultAsync(
            async () => await _accountService.AssignStaff(request).ConfigureAwait(false)
        ).ConfigureAwait(false);
    }

    [HttpGet("/api/clubs/staffs")]
    [EnableQuery]
    public  IActionResult GetClubStaff()   
    {
        return HandleResult(() =>  _clubService.GetMyStaff());
    }

    [Authorize(Roles = SystemRole.Staff)]
    [HttpGet("/api/clubs/staff/club")]
    [EnableQuery]
    public async Task<IActionResult> GetMyWorkingClub()   
    {
        return await HandleResultAsync(
            async () =>  await _clubService.GetMyWorkingClubAsync().ConfigureAwait(false)
        ).ConfigureAwait(false);
    }
}
