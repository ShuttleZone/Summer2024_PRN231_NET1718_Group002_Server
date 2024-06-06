using Microsoft.AspNetCore.Mvc;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Services.Reservation;
using ShuttleZone.Domain.WebRequests.Reservations;

namespace ShuttleZone.Api.Controllers
{
    public class ReservationController : BaseApiController
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost("make-booking")]
        public async Task<IActionResult> CreateBooking([FromBody] CreateReservationRequest request)
        {
            //placeholder for logined user
            var userId = new Guid("26A7CC4E-3F9B-4923-809E-2F9B771D994F");
            try
            {
                var result = await _reservationService.CreateReservation(request, userId, false);
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
