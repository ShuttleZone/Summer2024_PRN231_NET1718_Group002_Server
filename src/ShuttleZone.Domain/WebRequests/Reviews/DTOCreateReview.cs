using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.WebRequests;

public class DtoCreateReview
{
    public Guid clubId { get; set; }
    public RatingEnum Rating { get; set; }
    public string? Comment { get; set; }
}