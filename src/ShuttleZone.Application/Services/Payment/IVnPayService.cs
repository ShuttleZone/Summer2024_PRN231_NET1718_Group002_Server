using Microsoft.AspNetCore.Http;
using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.WebRequests.Payment;
using ShuttleZone.Domain.WebResponses.Payment;

namespace ShuttleZone.Application.Services.Payment;
[AutoRegister]
public interface IVnPayService
{
    string CreatePaymentUrl(HttpContext context, VnPayRequest request);
    VnPayResponse PaymentExecute(VnPayResponse response);
}
