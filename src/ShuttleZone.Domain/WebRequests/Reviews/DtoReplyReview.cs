namespace ShuttleZone.Domain.WebRequests;

public class DtoReplyReview
{
    public Guid Id { get; set; }
    public string? ReplyTitle { get; set; }
    public string? ReplyContent { get; set; }
}