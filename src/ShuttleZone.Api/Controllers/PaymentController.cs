using Microsoft.AspNetCore.Mvc;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Services.Payment;
using ShuttleZone.Domain.WebRequests.Payment;
using ShuttleZone.Domain.WebResponses.Payment;

namespace ShuttleZone.Api.Controllers
{
    public class PaymentController : BaseApiController
    {
        private readonly IVnPayService _vnPayService;
        public PaymentController(IVnPayService vnPayService)
        {
            _vnPayService = vnPayService;
        }

        [HttpPost("create-payment-url")]
        public IActionResult CreatePaymentUrl([FromBody] VnPayRequest request)
        {
            var context = HttpContext;
            var url = _vnPayService.CreatePaymentUrl(context, request);
            return Ok(url);
        }

        [HttpGet("payment-callback")]
        public IActionResult PaymentCallBack([FromQuery] VnPayResponse response)
        {
            Console.WriteLine("PaymentCallBack");
            try
            {
                return Ok(_vnPayService.PaymentExecute(response, true));
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpGet("/IPN")]
        public IActionResult IPN([FromQuery] VnPayResponse response)
        {
            try
            {
                return Ok(_vnPayService.PaymentExecute(response, true));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
