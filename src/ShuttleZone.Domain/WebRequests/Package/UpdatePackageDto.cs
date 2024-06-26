using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.WebRequests.Packages;

public record UpdatePackageDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    
    

}