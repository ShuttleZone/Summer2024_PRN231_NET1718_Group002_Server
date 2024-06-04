using Microsoft.AspNetCore.Http;
using ShuttleZone.Domain.WebRequests.Payment;
using ShuttleZone.Domain.WebResponses.Payment;

namespace ShuttleZone.Application.Services.Payment;

public interface IVnPayService
{
    string CreatePaymentUrl(HttpContext context, VnPayRequest request);
    VnPayResponse PaymentExecute(VnPayResponse response);
}
