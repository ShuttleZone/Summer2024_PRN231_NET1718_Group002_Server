using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.WebResponses.Package;

public record PackageResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public PackageStatus PackageStatus { get; set; }
    public PackageType PackageType { get; set; } 
    
    public ICollection<PackageUserDto>? PackageUser { get; set; } = new List<PackageUserDto>();
    
    public class PackageUserDto
    {
        public Guid UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PackageUserStatus PackageUserStatus { get; set; }

    }
}