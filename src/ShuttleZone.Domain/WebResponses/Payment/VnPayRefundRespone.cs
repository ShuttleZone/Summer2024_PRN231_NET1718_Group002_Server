namespace ShuttleZone.Domain.WebResponses.Payment
{
    public class VnPayRefundRespone
    {
        public string vnp_ResponseId { get; set; } = String.Empty;
        public string vnp_Command { get; set; } = String.Empty;
        public string vnp_TmnCode { get; set; } = String.Empty;
        public string vnp_TxnRef { get; set; } = String.Empty;
        public string vnp_Amount { get; set; } = String.Empty;
        public string vnp_OrderInfo { get; set; } = String.Empty;
        public string vnp_ResponseCode { get; set; } = String.Empty;
        public string vnp_Message { get; set; } = String.Empty;
        public string vnp_BankCode { get; set; } = String.Empty;
        public string vnp_PayDate { get; set; } = String.Empty;
        public string vnp_TransactionNo { get; set; } = String.Empty;
        public string vnp_TransactionType { get; set; } = String.Empty;
        public string vnp_TransactionStatus { get; set; } = String.Empty;
        public string vnp_PromotionCode { get; set; } = String.Empty;
        public string vnp_PromotionAmount { get; set; } = String.Empty;
        public string vnp_SecureHash { get; set; } = String.Empty;  
    }
}
