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
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Application.Services.Payment
{
    [AutoRegister]
    public class VnPayService : IVnPayService
    {
        private readonly VNPaySettings _vnPaySettings;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUser _user;

        public VnPayService(VNPaySettings vnPaySettings, IUnitOfWork unitOfWork,
            IHttpClientFactory httpClientFactory, IUser user)
        {
            _vnPaySettings = vnPaySettings;
            _unitOfWork = unitOfWork;
            _httpClientFactory = httpClientFactory;
            _user = user;
        }

        public string CreatePaymentUrl(HttpContext context, VnPayRequest vnPayRequest)
        {
            if (vnPayRequest.OrderType.Equals(VnPayConstansts.ORDER_TYPE_BOOKING, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(vnPayRequest.OrderInfo))
            {
                var reservationId = new Guid(vnPayRequest.OrderInfo ?? throw new Exception("Invalid reservation"));
                var reservation = _unitOfWork.ReservationRepository.Get(r => r.Id == reservationId) ?? throw new Exception("Đơn đặt chỗ không tồn tại");

                if (reservation.ReservationStatusEnum == ReservationStatusEnum.PAYSUCCEED)
                    throw new HttpException(400, "Đơn đặt chỗ đã được thanh toán");

            }
            else if (vnPayRequest.OrderType.Equals(VnPayConstansts.ORDER_TYPE_ADD_TO_WALLET, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(vnPayRequest.OrderInfo))
            {
                var walletId = new Guid(vnPayRequest.OrderInfo ?? throw new Exception("Ví không tồn tại"));
                var wallet = _unitOfWork.WalletRepository.Get(r => r.Id == walletId) ?? throw new Exception("Ví không tồn tại");
            }
            else if (vnPayRequest.OrderType.Equals(VnPayConstansts.ORDER_TYPE_JOIN_CONTEST, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(vnPayRequest.OrderInfo))
            {
                var contestId = new Guid(vnPayRequest.OrderInfo ?? throw new Exception("Cuộc thi không tồn tại"));
                var contest = _unitOfWork.ContestRepository.Get(r => r.Id == contestId) ?? throw new Exception("Cuộc thi không tồn tại");

                var reservationStartTime = _unitOfWork.ReservationRepository
                                         .Find(r => r.Id == contest.Reservation!.Id)
                                         .Include(r => r.ReservationDetails)
                                         .SelectMany(r => r.ReservationDetails.Select(rd => rd.StartTime))
                                         .Min();

                if (reservationStartTime < DateTime.Now)
                    throw new HttpException(400, "Cuộc thi đã bắt đầu");

                if (contest.ContestStatus == ContestStatusEnum.Closed)
                    throw new HttpException(400, "Cuộc thi đã kết thúc");

                var isJoined = contest.UserContests.Exists(c => c.ParticipantsId == new Guid(_user.Id ?? ""));
                if (isJoined)
                    throw new HttpException(400, "Bạn đã tham gia cuộc thi");

                var isSlotRemaining = contest.MaxPlayer > contest.UserContests.Count();
                if (!isSlotRemaining)
                    throw new HttpException(400, "Cuộc thi đã đủ người tham gia");

                vnPayRequest.OrderInfo = contestId + "," + _user.Id;
            }
            else if (vnPayRequest.OrderType.Equals(VnPayConstansts.ORDER_TYPE_PACKAGE, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(vnPayRequest.OrderInfo))
            {
                var packageId = new Guid(vnPayRequest.OrderInfo ?? throw new Exception("Gói không tồn tại"));
                var package = _unitOfWork.PackageRepository.Get(p => p.Id == packageId) ?? throw new Exception("Gói không tồn tại");
                vnPayRequest.OrderInfo = packageId + "," + _user.Id;
            }
            else
            {
                throw new HttpException(400, "Đơn hàng không hợp lệ");
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
                throw new Exception("Mã xác thực không hợp lệ");
            }
            if (isIPN)
            {
                var orderType = response.vnp_OrderInfo?.Split(",")[0] ?? "";
                var orderId = new Guid(response.vnp_OrderInfo?.Split(",")[1] ?? throw new Exception("Đơn hàng không hợp lệ"));
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
                    //if join contest add contest reservationid
                    ReservationId = orderType.Equals(VnPayConstansts.ORDER_TYPE_BOOKING, StringComparison.OrdinalIgnoreCase) ? orderId : null,
                    TxnRef = response.vnp_TxnRef,
                    TransactionNo = response.vnp_TransactionNo,
                    TransactionDate = response.vnp_PayDate
                };
                if (isPaySucceed)
                {
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
                        var wallet = _unitOfWork.WalletRepository.Get(w => w.Id == orderId) ?? throw new HttpException(400, "Ví không tồn tại");

                        wallet.Balance += (result / 100);
                        wallet.Transactions.Add(transaction);
                    }//update db for join contest
                    else if (orderType.Equals(VnPayConstansts.ORDER_TYPE_JOIN_CONTEST, StringComparison.OrdinalIgnoreCase))
                    {
                        var userId = new Guid(response.vnp_OrderInfo?.Split(",")[2] ?? throw new Exception("Người dùng không hợp lệ"));
                        var user = await _unitOfWork.UserRepository.Find(u => u.Id == userId).FirstOrDefaultAsync() ?? throw new Exception("Người dùng không hợp lệ");
                        var contest = _unitOfWork.ContestRepository.Find(c => c.Id == orderId).Include(c => c.UserContests).Include(c => c.Reservation).FirstOrDefault()
                            ?? throw new HttpException(400, "Cuộc thi không tồn tại");

                        contest.UserContests.Add(
                                                   new UserContest
                                                   {
                                                       ParticipantsId = user.Id,
                                                       ContestId = orderId
                                                   });
                        transaction.ReservationId = contest.Reservation!.Id;

                    }//update db for buy package
                    else if (orderType.Equals(VnPayConstansts.ORDER_TYPE_PACKAGE, StringComparison.OrdinalIgnoreCase))
                    {
                        var userId = new Guid(response.vnp_OrderInfo?.Split(",")[2] ?? throw new Exception("Người dùng không hợp lệ"));
                        var user = await _unitOfWork.UserRepository.Find(u => u.Id == userId).FirstOrDefaultAsync() ?? throw new Exception("Người dùng không hợp lệ");
                        var package = _unitOfWork.PackageRepository.Find(c => c.Id == orderId).FirstOrDefault()
                            ?? throw new HttpException(400, $"Package with id {orderId} is not existed");
                        var packageCheck = await _unitOfWork.PackageUserRepository
                            .ExistsAsync(p => p.UserId == new Guid(_user.Id!)
                                              && p.PackageUserStatus == PackageUserStatus.VALID
                                              || p.EndDate < DateTime.Now);
                        if (packageCheck) throw new ArgumentException("Hiện tại người dùng đã đăng kí gói. Hãy huỷ gói hiện tại để sử dụng gói khác");

                        await _unitOfWork.TransactionRepository.AddAsync(transaction);
                        await _unitOfWork.CompleteAsync();

                        var packageUser = new PackageUser
                        {
                            Id = new Guid(),
                            UserId = new Guid(_user.Id ?? throw new HttpException(401, "Bạn cần đăng nhập để thực hiện chức năng này")),
                            PackageId = orderId,
                            TransactionId = transaction.Id,
                            StartDate = DateTime.Now,
                            EndDate = package.PackageType == PackageType.MONTH ? DateTime.Now.AddMonths(1)
                            : package.PackageType == PackageType.YEAR ? DateTime.Now.AddYears(1)
                            : DateTime.Now.AddYears(100000)
                        };
                       
                        await _unitOfWork.PackageUserRepository.AddAsync(packageUser);
                        
                    }
                }
                // _unitOfWork.TransactionRepository.Add(transaction);
                var isSuccess = await _unitOfWork.CompleteAsync();
            }

            return response;
        }

        public async Task<VnPayQueryDrResponse?> QueryPaymentAsync(Guid reservationId)
        {
            var transaction = _unitOfWork.TransactionRepository.Get(t => t.ReservationId == reservationId)
                ?? throw new HttpException(400, "Giao dịch không tồn tại");
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
                ?? throw new HttpException(400, "Giao dịch không tồn tại"); 

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

