namespace ShuttleZone.Domain.WebRequests.Payment
{
    public class VnPayQueryRequest
    {
        public string vnp_RequestId { get; set; } = String.Empty;
        public string vnp_Version { get; set; } = "2.1.0";
        public string vnp_Command { get; set; } = String.Empty;
        public string vnp_TmnCode { get; set; } = String.Empty;

        //tick
        public string vnp_TxnRef { get; set; } = String.Empty; //db
        //id cua reservation
        public string vnp_OrderInfo { get; set; } = String.Empty;//db
        //
        public string vnp_TransactionNo { get; set; } = String.Empty;//db
        //paydate
        public string vnp_TransactionDate { get; set; } = String.Empty;//db
        //datetime.now
        public string vnp_CreateDate { get; set; } = String.Empty;
        //save
        public string vnp_IpAddr { get; set; } = String.Empty;//db
        //setting
        public string vnp_SecureHash { get; set; } = String.Empty;
        
    }

    public class VnPayRefundRequest : VnPayQueryRequest
    {
        //refund request
        public string vnp_CreateBy { get; set; } = String.Empty;
        public string vnp_Amount { get; set; } = String.Empty;
        public string vnp_TransactionType { get; set; } = String.Empty;
    }
}
