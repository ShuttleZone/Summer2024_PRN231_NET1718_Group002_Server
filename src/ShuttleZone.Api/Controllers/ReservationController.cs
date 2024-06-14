using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Services.Reservation;
using ShuttleZone.Application.Services.Token;
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
    

        [EnableQuery]
        public IActionResult Get()
        {      
            return Ok(_reservationService.GetMyReservation(UserId));
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
    }
}
