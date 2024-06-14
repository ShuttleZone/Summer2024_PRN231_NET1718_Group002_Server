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
            var response = _reservationService.GetMyReservationDetails(UserId);
            return Ok(response);
        }
      

    }
}
