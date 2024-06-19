namespace ShuttleZone.Domain.WebResponses.Payment
{
    public class VnPayResponse
    {
        public string vnp_Amount { get; set; } = String.Empty;
        public string vnp_BankCode { get; set; } = String.Empty;
        public string vnp_BankTranNo { get; set; } = String.Empty;
        public string vnp_CardType { get; set; } = String.Empty;
        public string vnp_OrderInfo { get; set; } = String.Empty;
        public string vnp_PayDate { get; set; } = String.Empty;
        public string vnp_ResponseCode { get; set; } = String.Empty;
        public string vnp_TmnCode { get; set; } = String.Empty;
        public string vnp_TransactionNo { get; set; } = String.Empty;
        public string vnp_TransactionStatus { get; set; } = String.Empty;
        public string vnp_TxnRef { get; set; } = String.Empty;
        public string vnp_SecureHash { get; set; } = String.Empty;

    }
}
