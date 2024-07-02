namespace ShuttleZone.Domain.WebResponses.Wallets
{
    public class WalletResponse
    {
        public Guid Id { get; set; }
        public double Balance { get; set; } = 0;
        public Guid UserId { get; set; }
    }
}
