﻿using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Application.Services.Payment;
using ShuttleZone.Domain.WebRequests.Payment;
using ShuttleZone.Domain.WebResponses.Payment;
using Exception = System.Exception;

namespace ShuttleZone.Api.Controllers
{
    public class PaymentController : BaseApiController
    {
        private readonly IVnPayService _vnPayService;
        private readonly IPayOsService _payOsService;
        public PaymentController(IVnPayService vnPayService, IPayOsService payOsService)
        {
            _vnPayService = vnPayService;
            _payOsService = payOsService;
        }

        [HttpPost("create-payment-url")]
        public IActionResult CreatePaymentUrl([FromBody] VnPayRequest request)
        {
            var context = HttpContext;          
            return HandleResult(() => _vnPayService.CreatePaymentUrl(context, request));

        }

        [HttpGet("payment-callback")]
        public async Task<IActionResult> PaymentCallBack([FromQuery] VnPayResponse response)
        {
            return await HandleResultAsync(
            async () =>  await _vnPayService.PaymentExecuteAsync(response).ConfigureAwait(false)
            ).ConfigureAwait(false);
        }

        [HttpGet("/IPN")]
        public async Task<IActionResult> IPN([FromQuery] VnPayResponse response)
        {
            return await HandleResultAsync(
            async () => await _vnPayService.PaymentExecuteAsync(response, true).ConfigureAwait(false)
            ).ConfigureAwait(false);

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

        [HttpPost("/create-payment-link-PayOs")]
        public async Task<IActionResult> GetPayOsPaymentLink([FromQuery] PayOsRequest request)
        {
            try
            {
                var result = await _payOsService.CreatePaymentLinkPackage(request);
                
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet("/GetPayOsOrder/{orderId}")]
        public async Task<IActionResult> GetOrder([FromRoute] int orderId)
        {
            try
            {
                var result = await _payOsService.GetOrder(orderId);
                return Ok(result);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }

        }
        

    }
}
