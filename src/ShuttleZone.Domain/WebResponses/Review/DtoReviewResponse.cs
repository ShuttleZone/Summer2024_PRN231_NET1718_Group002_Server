using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.WebResponses.Review;

public class DtoReviewsResponse
{
    public RatingEnum Rating { get; set; }
    public string? Comment { get; set; }
    public string? ReplyContent { get; set; }
    public DateTime ReplyTime { get; set; }
    public string? ReplyPerson { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public string? CreatedBy { get; set; } = string.Empty;
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
}