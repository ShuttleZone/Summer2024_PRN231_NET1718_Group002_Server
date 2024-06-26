using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.WebResponses.Package;

public record PackageResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public PackageStatus? PackageStatus { get; set; }
}