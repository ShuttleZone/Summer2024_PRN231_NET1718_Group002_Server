using Microsoft.AspNetCore.Mvc;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Services.Reservation;
using ShuttleZone.Domain.WebRequests.Reservations;
using ShuttleZone.Domain.WebResponses.Club;

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
        public async Task<IActionResult> CreateBooking(CreateReservationRequest request)
        {
            await _reservationService.CreateReservation(request);
            return Ok();
        }
    }
}
