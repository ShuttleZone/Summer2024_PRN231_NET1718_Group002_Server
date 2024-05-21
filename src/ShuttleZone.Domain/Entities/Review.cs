using ShuttleZone.Domain.Common;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities;

public class Review : BaseAuditableEntity<Review>
{
    public Guid ReviewId { get; set; }
    public RatingEnum Rating { get; set; }
    public string? Comment { get; set; }
    
}