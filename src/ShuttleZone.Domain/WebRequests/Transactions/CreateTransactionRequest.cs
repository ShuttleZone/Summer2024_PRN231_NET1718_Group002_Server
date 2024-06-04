using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.WebRequests.Transactions
{
    public class CreateTransactionRequest
    {
        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.VNPAY;
        public double Amount { get; set; }
        public TransactionStatusEnum TransactionStatus { get; set; }
               
    }
}
