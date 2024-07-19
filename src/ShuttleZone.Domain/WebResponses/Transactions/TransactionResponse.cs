using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.WebResponses.Transactions
{
    public class TransactionResponse
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; } 
        public double Amount { get; set; }
        public string TransactionStatus { get; set; } = string.Empty;
    }
}
