using ShuttleZone.Domain.Common;

namespace ShuttleZone.Domain.Entities;

public class Foo : BaseEntity<Guid>
{
    public required string Name { get; set; }
}
