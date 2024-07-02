using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Services.Reservation;
using ShuttleZone.Domain.WebRequests.Reservations;

namespace ShuttleZone.Api.Controllers
{
    public class ReservationController(IReservationService _reservationService) : BaseApiController
    {
        [EnableQuery]
        public IActionResult Get()
        {
            var query = _reservationService.GetMyReservation(UserId);
            return Ok(query);
        }

        [HttpPost("make-booking")]
        [Authorize]
        public async Task<IActionResult> CreateBooking([FromForm] CreateReservationRequest request)
        {
            try
            {
                var result = await _reservationService.CreateReservation(request, UserId, false);
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
        [EnableQuery]
        public async Task<IActionResult> Put(Guid key)
        {
            return await HandleResultAsync(
            async () => await _reservationService.CancelReservation(key).ConfigureAwait(false)
            ).ConfigureAwait(false);

        }
    }
}
