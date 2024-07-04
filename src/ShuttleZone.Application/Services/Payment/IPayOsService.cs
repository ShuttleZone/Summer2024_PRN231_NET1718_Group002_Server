using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.WebRequests.Payment;
using ShuttleZone.Domain.WebResponses.Payment;

namespace ShuttleZone.Application.Services.Payment;

public interface IPayOsService
{
    Task<PayOsResponse> CreatePaymentLinkPackage(PayOsRequest request);
    Task<PayOsResponse> GetOrder(int orderId);
}