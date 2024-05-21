using System.ComponentModel.DataAnnotations;
using ShuttleZone.Domain.Common;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities;

public class Review : BaseAuditableEntity<Review>
{
    [Key]
    public Guid ReviewId { get; set; }
    public RatingEnum Rating { get; set; }
    public string? Comment { get; set; }
    
    public Guid? ReviewerId { get; set; }
    public User? Reviewer { get; set; }
    
    public Guid? ClubId { get; set; }
    public Club? Club { get; set; }
}