using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.WebResponses.Package;

public class UserPackageResponseDto
{
    public Guid UserId { get; set; }
    public Guid PackageId { get; set; }
    
    public PackageUserStatus PackageUserStatus { get; set; } 
        
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public PackageDto? Package { get; set; }

    
    public class PackageDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public PackageStatus PackageStatus { get; set; }
        public PackageType PackageType { get; set; }

    }
}

