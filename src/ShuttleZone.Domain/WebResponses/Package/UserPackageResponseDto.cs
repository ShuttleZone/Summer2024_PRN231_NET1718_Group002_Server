using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.WebResponses.Package;

public class UserPackageResponseDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public PackageStatus PackageStatus { get; set; }
    public PackageType PackageType { get; set; }
    public ICollection<PackageUserDto>? PackageUser { get; set; } = new List<PackageUserDto>();
    
    public class PackageUserDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PackageUserStatus PackageUserStatus { get; set; }

    }
}

