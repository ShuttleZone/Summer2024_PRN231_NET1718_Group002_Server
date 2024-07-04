using Azure;
using Net.payOS;
using Net.payOS.Types;
using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.WebRequests.Payment;
using ShuttleZone.Domain.WebResponses.Payment;

namespace ShuttleZone.Application.Services.Payment;

[AutoRegister]
public class PayOsService : IPayOsService
{
    private readonly PayOS _payOs;

    public PayOsService(PayOS payOs)
    {
        _payOs = payOs;
    }
    
    public async Task<PayOsResponse> CreatePaymentLinkPackage(PayOsRequest request)
    {
        try
        {
            var orderCode = BitConverter.ToUInt32(request.productId.ToByteArray(), 0);
            var item = new ItemData(request.productName, 1, request.price);
            var items = new List<ItemData>();
            items.Add(item);
            var requestReturnUrl = request.returnUrl + "/?orderCode=" + orderCode;
            PaymentData paymentData = new PaymentData(orderCode, request.price, request.description, items, request.cancelUrl, requestReturnUrl);

            CreatePaymentResult createPayment = await _payOs.createPaymentLink(paymentData);
            var response = new PayOsResponse();
            response.error = 0;
            response.messsage = "success";
            response.data = createPayment.checkoutUrl;
            return response;
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw new Exception(exception.Message);
        }
    }

    public async Task<PayOsResponse> GetOrder(int orderId)
    {
        try
        {
            PaymentLinkInformation paymentLinkInformation = await _payOs.getPaymentLinkInformation(orderId);
            var response = new PayOsResponse();
            response.error = 0;
            response.messsage = "success";
            response.data = paymentLinkInformation;
            return response;
        }
        catch (System.Exception exception)
        {
            throw new Exception(exception.Message);
        }
    }
}