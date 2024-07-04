namespace ShuttleZone.Domain.WebRequests.Payment;

public record PayOsRequest
{
    public Guid productId { get; set; }
    public string productName { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
    public int price { get; set; }
    public string returnUrl { get; set; } = string.Empty;
    public string cancelUrl { get; set; } = string.Empty;
}