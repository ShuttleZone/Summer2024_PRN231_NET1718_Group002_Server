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
using ShuttleZone.Common.Exceptions;
using System.Text.Json;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace ShuttleZone.Application.Services.Payment
{
    [AutoRegister]
    public class VnPayService : IVnPayService
    {
        private readonly VNPaySettings _vnPaySettings;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpClientFactory _httpClientFactory;

        public VnPayService(IOptions<VNPaySettings> vnPaySettings, IUnitOfWork unitOfWork,
            IHttpClientFactory httpClientFactory)
        {
            _vnPaySettings = vnPaySettings.Value;
            _unitOfWork = unitOfWork;
            _httpClientFactory = httpClientFactory;
        }

        public string CreatePaymentUrl(HttpContext context, VnPayRequest vnPayRequest)
        {
            if (vnPayRequest.OrderType.Equals(VnPayConstansts.ORDER_TYPE_BOOKING, StringComparison.OrdinalIgnoreCase) && string.IsNullOrEmpty(vnPayRequest.OrderInfo))
            {
                var reservationId = new Guid(vnPayRequest.OrderInfo ?? throw new Exception("Invalid reservation"));
                var reservation = _unitOfWork.ReservationRepository.Get(r => r.Id == reservationId) ?? throw new Exception("Invalid reservation");

                if (reservation.ReservationStatusEnum == ReservationStatusEnum.PAYSUCCEED)
                    throw new HttpException(400, "Reservation is already paid");

            }
            else if (vnPayRequest.OrderType.Equals(VnPayConstansts.ORDER_TYPE_ADD_TO_WALLET, StringComparison.OrdinalIgnoreCase) && string.IsNullOrEmpty(vnPayRequest.OrderInfo))
            {
                var walletId = new Guid(vnPayRequest.OrderInfo ?? throw new Exception("Invalid wallet"));
                var wallet = _unitOfWork.WalletRepository.Get(r => r.Id == walletId) ?? throw new Exception("Invalid wallet");
            }

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
            vnpay.AddRequestData(VnPayConstansts.ORDER_INFOR, vnPayRequest.OrderType + "," + vnPayRequest.OrderInfo ?? "");
            vnpay.AddRequestData(VnPayConstansts.ORDER_TYPE, vnPayRequest.OrderType ?? "");
            vnpay.AddRequestData(VnPayConstansts.RETURN_URL, _vnPaySettings.ReturnUrl);
            vnpay.AddRequestData(VnPayConstansts.TXN_REF, tick);

            string paymentUrl = vnpay.CreateRequestUrl(_vnPaySettings.BaseUrl, _vnPaySettings.HashSecret);

            return paymentUrl;
        }

        public async Task<VnPayResponse> PaymentExecuteAsync(VnPayResponse response, bool isIPN = false)
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
                var orderType = response.vnp_OrderInfo?.Split(",")[0] ?? "";
                var orderId = new Guid(response.vnp_OrderInfo?.Split(",")[1] ?? throw new Exception("Invalid order"));
                Double.TryParse(response.vnp_Amount, out double result);

                var isPaySucceed = (response.vnp_ResponseCode?.Equals("00") ?? false)
                    && (response.vnp_TransactionStatus?.Equals("00") ?? false);

                var transaction = new Domain.Entities.Transaction()
                {
                    Id = new Guid(),
                    PaymentMethod = PaymentMethod.VNPAY,
                    Amount = result,
                    TransactionStatus = isPaySucceed
                    ? TransactionStatusEnum.SUCCESS : TransactionStatusEnum.FAIL,
                    ReservationId = orderType.Equals(VnPayConstansts.ORDER_TYPE_BOOKING, StringComparison.OrdinalIgnoreCase) ? orderId : null,
                    TxnRef = response.vnp_TxnRef,
                    TransactionNo = response.vnp_TransactionNo,
                    TransactionDate = response.vnp_PayDate
                };

                
                //update db for booking
                if (orderType.Equals(VnPayConstansts.ORDER_TYPE_BOOKING, StringComparison.OrdinalIgnoreCase))
                {
                    var reservation = _unitOfWork.ReservationRepository.Find(r => r.Id == orderId)
                 .Include(r => r.ReservationDetails).FirstOrDefault();

                    if (reservation != null)
                    {
                        foreach (var detail in reservation.ReservationDetails)
                        {
                            detail.ReservationDetailStatus = isPaySucceed ? ReservationStatusEnum.PAYSUCCEED : ReservationStatusEnum.PAYFAIL;
                        }

                        reservation.ReservationStatusEnum = isPaySucceed ? ReservationStatusEnum.PAYSUCCEED : ReservationStatusEnum.PAYFAIL;
                    }
                    _unitOfWork.TransactionRepository.Add(transaction);

                }//update db for add to wallet
                else if (orderType.Equals(VnPayConstansts.ORDER_TYPE_ADD_TO_WALLET, StringComparison.OrdinalIgnoreCase))
                {
                    var wallet = _unitOfWork.WalletRepository.Get(w => w.Id == orderId) ?? throw new HttpException(400, "Invalid wallet");

                    wallet.Balance += (result/100);
                    wallet.Transactions.Add(transaction);
                }

                var isSuccess = await _unitOfWork.CompleteAsync();
            }

            return response;
        }

        public async Task<VnPayQueryDrResponse?> QueryPaymentAsync(Guid reservationId)
        {
            var transaction = _unitOfWork.TransactionRepository.Get(t => t.ReservationId == reservationId)
                ?? throw new HttpException(400, "Transaction with reservation not found");
            var queryRequest = new VnPayQueryRequest()
            {
                vnp_Command = VnPayConstansts.QUERY_COMMAND,
                vnp_TmnCode = _vnPaySettings.TmnCode,
                vnp_TransactionNo = transaction.TransactionNo,
                vnp_CreateDate = DateTime.Now.ToString("yyyyMMddHHmmss"),
                vnp_IpAddr = "127.0.0.1",
                vnp_OrderInfo = transaction.ReservationId.ToString() ?? "",
                vnp_RequestId = GenerateRequestId(),
                vnp_Version = _vnPaySettings.Version,
                vnp_TransactionDate = transaction.TransactionDate,
                vnp_TxnRef = transaction.TxnRef,

            };
            queryRequest.vnp_SecureHash = Utils.HmacSHA512(_vnPaySettings.HashSecret, GenerateChecksumData(queryRequest));

            var httpClient = _httpClientFactory.CreateClient();
            var jsonRequest = JsonSerializer.Serialize(queryRequest);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(_vnPaySettings.ApiUrl, content);
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };

            VnPayQueryDrResponse result = JsonSerializer.Deserialize<VnPayQueryDrResponse>(jsonResponse, options)!;

            return result;
        }

        public async Task<VnPayRefundRespone?> RefundPaymentAsync(Guid reservationId, double refundAmount = 0, string transactionType = VnPayConstansts.TOTAL_REFUND)
        {

            var transaction = _unitOfWork.TransactionRepository.Get(t => t.ReservationId == reservationId)
                ?? throw new HttpException(400, "Transaction with reservation not found");

            var refundRequest = new VnPayRefundRequest()
            {
                vnp_RequestId = GenerateRequestId(),
                vnp_Version = _vnPaySettings.Version,
                vnp_Command = VnPayConstansts.REFUND_COMMAND,
                vnp_TmnCode = _vnPaySettings.TmnCode,
                vnp_CreateDate = DateTime.Now.ToString("yyyyMMddHHmmss"),
                vnp_IpAddr = "127.0.0.1",
                vnp_OrderInfo = transaction.ReservationId.ToString() ?? "",
                vnp_TransactionNo = transaction.TransactionNo,
                vnp_TxnRef = transaction.TxnRef,
                vnp_TransactionDate = transaction.TransactionDate,
                vnp_Amount = refundAmount == 0 ? transaction.Amount.ToString() : refundAmount.ToString(),
                vnp_TransactionType = transactionType,
                vnp_CreateBy = "user",
            };
            refundRequest.vnp_SecureHash = Utils.HmacSHA512(_vnPaySettings.HashSecret, GenerateChecksumData(refundRequest));

            var httpClient = _httpClientFactory.CreateClient();
            var jsonRequest = JsonSerializer.Serialize(refundRequest);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(_vnPaySettings.ApiUrl, content);
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<VnPayRefundRespone>(jsonResponse);

            return result;
        }
        private string GenerateChecksumData(VnPayQueryRequest request)
        {
            return $"{request.vnp_RequestId}|{request.vnp_Version}|{request.vnp_Command}|{request.vnp_TmnCode}|{request.vnp_TxnRef}|{request.vnp_TransactionDate}|{request.vnp_CreateDate}|{request.vnp_IpAddr}|{request.vnp_OrderInfo}";
        }

        private string GenerateChecksumData(VnPayRefundRequest request)
        {
            return $"{request.vnp_RequestId}|{request.vnp_Version}|{request.vnp_Command}|{request.vnp_TmnCode}|{request.vnp_TransactionType}|{request.vnp_TxnRef}|{request.vnp_Amount}|{request.vnp_TransactionNo}|{request.vnp_TransactionDate}|{request.vnp_CreateBy}|{request.vnp_CreateDate}|{request.vnp_IpAddr}|{request.vnp_OrderInfo}";
        }

        public string GenerateRequestId()
        {
            string merchantPrefix = "ShuttleZone";
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            string randomSuffix = new Random().Next(1000, 9999).ToString();

            return $"{merchantPrefix}-{timestamp}-{randomSuffix}";
        }
    }
}

