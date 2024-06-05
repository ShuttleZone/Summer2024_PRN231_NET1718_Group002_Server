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
            var result = await _reservationService.CreateReservation(request);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}
