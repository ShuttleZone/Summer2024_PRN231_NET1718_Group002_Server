using ShuttleZone.Domain.Common;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities
{
    public class Package : BaseEntity<Guid>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public PackageStatus? PackageStatus { get; set; }

        public ICollection<PackageUser>? PackageUser { get; set; }        
    }
}
