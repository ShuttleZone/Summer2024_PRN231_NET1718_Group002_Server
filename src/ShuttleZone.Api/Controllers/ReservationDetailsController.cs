using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Services.Reservation;
using ShuttleZone.Application.Services.Token;

namespace ShuttleZone.Api.Controllers
{
    public class ReservationDetailsController : BaseApiController
    {
        private readonly IReservationService _reservationService;
        private readonly ITokenService _tokenService;
        

        public ReservationDetailsController(IReservationService reservationService, ITokenService tokenService)
        {
            _reservationService = reservationService;
            _tokenService = tokenService;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            //placeholder for logined user
            var userId = new Guid("26A7CC4E-3F9B-4923-809E-2F9B771D994F");
            var authModel = _tokenService.GetAuthModel(GetJwtToken());

            var response = _reservationService.GetMyReservationDetails(authModel.UserId);

            return Ok(response);
        }
        private string GetJwtToken()
        {
            var authorizationHeader = HttpContext.Request.Headers["Authorization"].ToString();
            var token = authorizationHeader.Replace("bearer", "", StringComparison.OrdinalIgnoreCase).Trim();
            return token;
        }

    }
}
