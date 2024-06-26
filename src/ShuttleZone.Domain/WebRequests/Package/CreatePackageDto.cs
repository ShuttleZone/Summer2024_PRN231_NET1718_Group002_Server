using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.WebRequests.Packages;

public record CreatePackageDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
}