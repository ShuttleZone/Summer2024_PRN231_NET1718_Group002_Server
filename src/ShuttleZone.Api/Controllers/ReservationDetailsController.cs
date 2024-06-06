using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Services.Reservation;

namespace ShuttleZone.Api.Controllers
{
    public class ReservationDetailsController : BaseApiController
    {
        private readonly IReservationService _reservationService;
        

        public ReservationDetailsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            //placeholder for logined user
            var userId = new Guid("26A7CC4E-3F9B-4923-809E-2F9B771D994F");

            var response = _reservationService.GetMyReservationDetails(userId);

            return Ok(response);
        }
    }
}
