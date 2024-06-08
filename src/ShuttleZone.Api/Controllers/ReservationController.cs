using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Application.Services.Reservation;
using ShuttleZone.Application.Services.Token;
using ShuttleZone.Domain.WebRequests.Reservations;

namespace ShuttleZone.Api.Controllers
{
    public class ReservationController : BaseApiController
    {
        private readonly IReservationService _reservationService;
        private readonly ITokenService _tokenService;
        private readonly IUser _currentUser;

        public ReservationController(IReservationService reservationService, ITokenService tokenService, IUser currentUser)
        {
            _reservationService = reservationService;
            _tokenService = tokenService;
            _currentUser = currentUser;
        }
        
        private string GetJwtToken()
        {
            var authorizationHeader = HttpContext.Request.Headers["Authorization"].ToString();
            var token = authorizationHeader.Replace("bearer", "", StringComparison.OrdinalIgnoreCase).Trim();
            return token;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            //placeholder for logined user
            // var userId = new Guid("26A7CC4E-3F9B-4923-809E-2F9B771D994F");
            var authModel = _tokenService.GetAuthModel(GetJwtToken());
            return Ok(_reservationService.GetMyReservation(authModel.UserId));
        }

        [HttpPost("make-booking")]
        [Authorize]
        public async Task<IActionResult> CreateBooking([FromForm] CreateReservationRequest request)
        {
            //placeholder for logined user
            // var userId = new Guid("26A7CC4E-3F9B-4923-809E-2F9B771D994F");
            // var authModel = _tokenService.GetAuthModel(GetJwtToken());
            try
            {
                ArgumentNullException.ThrowIfNull(_currentUser.Id, nameof(request)); // should throw other exception type and handle it in the catch block
                var result = await _reservationService.CreateReservation(request, new Guid(_currentUser.Id), false);
                if (result)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("staff/make-booking")]
        public async Task<IActionResult> StaffCreateBooking([FromBody] CreateReservationRequest request)
        {           
            try
            {
                var result = await _reservationService.CreateReservation(request);
                if (result)
                    return Ok();
                else
                    return BadRequest();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
