using Azure;
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
        public async Task<IActionResult> PaymentCallBack([FromQuery] VnPayResponse response)
        {
            try
            {
                var result = await _vnPayService.PaymentExecuteAsync(response, true);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/IPN")]
        public async Task<IActionResult> IPN([FromQuery] VnPayResponse response)
        {
            try
            {
                var result = await _vnPayService.PaymentExecuteAsync(response, true);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("/query")]
        public async Task<IActionResult> QueryPayment(Guid reservationId)
        {
            try
            {
                var result = await _vnPayService.QueryPaymentAsync(reservationId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("/refund")]
        public async Task<IActionResult> RefundPayment(Guid reservationId)
        {
            try
            {
                var result = await _vnPayService.RefundPaymentAsync(reservationId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
