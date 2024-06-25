using ShuttleZone.Domain.Common;

namespace ShuttleZone.Domain.Entities
{
    public class Package : BaseEntity<Guid>
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public ICollection<PackageUser>? PackageUser { get; set; }        
    }
}
