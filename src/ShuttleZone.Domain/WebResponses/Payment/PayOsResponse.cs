namespace ShuttleZone.Domain.WebResponses.Payment;

public record PayOsResponse
{
    public int error { get; set; }
    public string messsage { get; set; } = string.Empty;
    public object? data { get; set; }
}