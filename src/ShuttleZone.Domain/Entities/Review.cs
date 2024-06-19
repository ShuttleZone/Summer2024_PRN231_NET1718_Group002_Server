using ShuttleZone.Domain.Common;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities;

public class Review : BaseAuditableEntity<Guid>
{
    public RatingEnum Rating { get; set; }
    public string? Comment { get; set; }
    
    public Guid? ReviewerId { get; set; }
    public User? Reviewer { get; set; }
    
    public Guid? ClubId { get; set; }
    public Club? Club { get; set; }
    
    public string? ReplyContent { get; set; }
    public DateTime ReplyTime { get; set; }
    public string? ReplyPerson { get; set; }
}
