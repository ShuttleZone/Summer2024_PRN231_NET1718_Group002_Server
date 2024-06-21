using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.WebResponses.Review;

public class DtoReviewsResponse
{
    public RatingEnum Rating { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public string? ReplyTitle { get; set; }
    public string? ReplyContent { get; set; }
    public DateTime ReplyTime { get; set; }
    public string? ReplyPerson { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public string? CreatedBy { get; set; } = string.Empty;
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
    public string? ClubName { get; set; }
    // public DateTime UserCreatedTime { get; set; }
    public required string ClubDescription { get; set; }
    public required string ClubAddress { get; set; }
    public required string ClubPhone { get; set; }

}