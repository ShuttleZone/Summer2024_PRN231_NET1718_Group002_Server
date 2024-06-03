using Microsoft.Extensions.Options;
using ShuttleZone.Application.Helpers;
using ShuttleZone.Common.Constants;
using ShuttleZone.Common.Settings;
using ShuttleZone.Domain.WebRequests.Payment;
using ShuttleZone.Domain.WebResponses.Payment;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace ShuttleZone.Application.Services.Payment
{
    public class VnPayService : IVnPayService
    {
        private readonly VNPaySettings _vnPaySettings;
        public VnPayService(IOptions<VNPaySettings> vnPaySettings)
        {
            _vnPaySettings = vnPaySettings.Value;
        }

        public string CreatePaymentUrl(HttpContext context, VnPayRequest vnPayRequest)
        {
            var tick = DateTime.Now.Ticks.ToString();

            var vnpay = new VnPayLibrary();

            vnpay.AddRequestData(VnPayConstansts.VERSION, _vnPaySettings.Version);
            vnpay.AddRequestData(VnPayConstansts.COMMAND, VnPayConstansts.PAY_COMMAND);
            vnpay.AddRequestData(VnPayConstansts.TMN_CODE, _vnPaySettings.TmnCode);
            vnpay.AddRequestData(VnPayConstansts.AMOUNT, (vnPayRequest.Amount * 100).ToString());
            vnpay.AddRequestData(VnPayConstansts.CREATE_DATE, vnPayRequest.CreatedDate.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData(VnPayConstansts.CURR_CODE, _vnPaySettings.CurrencyCode);
            vnpay.AddRequestData(VnPayConstansts.IP_ADDRESS, Utils.GetIpAddress(context));
            vnpay.AddRequestData(VnPayConstansts.LOCALE, _vnPaySettings.Locale);
            vnpay.AddRequestData(VnPayConstansts.ORDER_INFOR, vnPayRequest.OrderInfo ?? "");
            vnpay.AddRequestData(VnPayConstansts.ORDER_TYPE, vnPayRequest.OrderType ?? "");
            vnpay.AddRequestData(VnPayConstansts.RETURN_URL, _vnPaySettings.ReturnUrl);
            vnpay.AddRequestData(VnPayConstansts.TXN_REF, tick);

            string paymentUrl = vnpay.CreateRequestUrl(_vnPaySettings.BaseUrl, _vnPaySettings.HashSecret);


            return paymentUrl;
        }

        public VnPayResponse PaymentExecute(VnPayResponse response)
        {
            var vnpay = new VnPayLibrary();

            Type type = response.GetType();

            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                vnpay.AddResponseData(property.Name, property?.GetValue(response)?.ToString() ?? "");
            }

            bool checkSignature = vnpay.ValidateSignature(response.vnp_SecureHash ?? "", _vnPaySettings.HashSecret);

            if (!checkSignature)
            {
                throw new Exception("SecureHash does not match");
            }

            return response;
        }
    }
}
