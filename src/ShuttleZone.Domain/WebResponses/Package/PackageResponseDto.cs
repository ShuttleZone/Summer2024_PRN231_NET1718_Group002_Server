namespace ShuttleZone.Domain.WebResponses.Package;

public record PackageResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string PackageStatus { get; set; } = null!;
    public string PackageType { get; set; } = null!;
}