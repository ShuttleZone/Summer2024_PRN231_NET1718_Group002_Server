namespace ShuttleZone.Domain.WebRequests.Payment
{
    public class VnPayRequest
    {
        public string OrderInfo { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string OrderType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Amount { get; set; }
       
    }
}
