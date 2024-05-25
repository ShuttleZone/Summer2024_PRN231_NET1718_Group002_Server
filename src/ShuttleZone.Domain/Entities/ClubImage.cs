using ShuttleZone.Domain.Common;

namespace ShuttleZone.Domain.Entities;

public class ClubImage : BaseEntity<Guid>
{
    public required string ImageUrl { get; set; }
    
    public required Guid ClubId { get; set; }
    public required Club Club { get; set; }
}
