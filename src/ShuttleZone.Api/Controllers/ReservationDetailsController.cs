using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Application.Services.Reservation;
using ShuttleZone.Application.Services.Token;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Api.Controllers
{
    public class ReservationDetailsController : BaseApiController
    {
        private readonly IReservationService _reservationService;
        private readonly ITokenService _tokenService;
        private readonly IUser _user;
        

        public ReservationDetailsController(IReservationService reservationService, ITokenService tokenService, IUser user)
        {
            _reservationService = reservationService;
            _tokenService = tokenService;
            _user = user;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            //placeholder for logined user
            // var userId = new Guid("26A7CC4E-3F9B-4923-809E-2F9B771D994F");
            // var authModel = _tokenService.GetAuthModel(GetJwtToken());
            var userId = new Guid(_user.Id?? throw new ArgumentNullException());

            var response = _reservationService.GetMyReservationDetails(userId);
            return Ok(response);
        }

        [EnableQuery]
        public async Task<IActionResult> Put(int key)
        {
            return await HandleResultAsync(
            async () => await _reservationService.CancelReservationDetail(key).ConfigureAwait(false)
            ).ConfigureAwait(false);
        }

    }
}
