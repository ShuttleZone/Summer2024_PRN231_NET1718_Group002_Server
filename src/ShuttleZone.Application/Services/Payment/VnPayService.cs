using Microsoft.Extensions.Options;
using ShuttleZone.Application.Helpers;
using ShuttleZone.Common.Constants;
using ShuttleZone.Common.Settings;
using ShuttleZone.Domain.WebRequests.Payment;
using ShuttleZone.Domain.WebResponses.Payment;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using ShuttleZone.Common.Attributes;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Domain.Enums;
using Azure;
using ShuttleZone.Common.Exceptions;

namespace ShuttleZone.Application.Services.Payment
{
    [AutoRegister]
    public class VnPayService : IVnPayService
    {
        private readonly VNPaySettings _vnPaySettings;
        private readonly IUnitOfWork _unitOfWork;

        public VnPayService(IOptions<VNPaySettings> vnPaySettings, IUnitOfWork unitOfWork)
        {
            _vnPaySettings = vnPaySettings.Value;
            _unitOfWork = unitOfWork;
        }

        public string CreatePaymentUrl(HttpContext context, VnPayRequest vnPayRequest)
        {
            var reservationId = new Guid(vnPayRequest.OrderInfo ?? throw new Exception("Invalid reservation"));
            var reservation = _unitOfWork.ReservationRepository.Get(r => r.Id == reservationId) ?? throw new Exception("Invalid reservation");

            if (reservation.ReservationStatusEnum == ReservationStatusEnum.PAYSUCCEED)
                throw new HttpException(400, "Reservation is already paid");

            var tick = DateTime.Now.Ticks.ToString();

            var vnpay = new VnPayLibrary();

            vnpay.AddRequestData(VnPayConstansts.VERSION, _vnPaySettings.Version);
            vnpay.AddRequestData(VnPayConstansts.COMMAND, VnPayConstansts.PAY_COMMAND);
            vnpay.AddRequestData(VnPayConstansts.TMN_CODE, _vnPaySettings.TmnCode);
            vnpay.AddRequestData(VnPayConstansts.AMOUNT, (vnPayRequest.Amount * 100).ToString());
            vnpay.AddRequestData(VnPayConstansts.CREATE_DATE, DateTime.Now.ToString("yyyyMMddHHmmss"));
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

        public async Task<VnPayResponse> PaymentExecute(VnPayResponse response, bool isIPN = false)
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
            if (isIPN)
            {
                Double.TryParse(response.vnp_Amount, out double result);
                var reservationId = new Guid(response.vnp_OrderInfo ?? throw new Exception("Invalid reservation"));
                var reservation = _unitOfWork.ReservationRepository.Get(r => r.Id == reservationId) ?? throw new Exception("Invalid reservation");

                var isPaySucceed = (response.vnp_ResponseCode?.Equals("00") ?? false)
                    && (response.vnp_TransactionStatus?.Equals("00") ?? false);

                _unitOfWork.TransactionRepository.Add(new Domain.Entities.Transaction()
                {
                    Id = new Guid(),
                    PaymentMethod = PaymentMethod.VNPAY,
                    Amount = result,
                    TransactionStatus = isPaySucceed
                    ? TransactionStatusEnum.SUCCESS : TransactionStatusEnum.FAIL,
                    ReservationId = reservationId
                });

                foreach(var detail in reservation.ReservationDetails)
                {
                    detail.ReservationDetailStatus = isPaySucceed ? ReservationStatusEnum.PAYSUCCEED : ReservationStatusEnum.PAYFAIL;
                }

                reservation.ReservationStatusEnum = isPaySucceed ? ReservationStatusEnum.PAYSUCCEED : ReservationStatusEnum.PAYFAIL;

                await _unitOfWork.CompleteAsync();
            }

            return response;
        }
    }
}
