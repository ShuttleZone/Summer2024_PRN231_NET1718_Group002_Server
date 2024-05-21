using ShuttleZone.Domain.Common;

namespace ShuttleZone.Domain.Entities;

public class ClubImage : BaseEntity<ClubImage>
{
    public Guid ImageId { get; set; }
    public string? ImageUrl { get; set; }
    
}