using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.WebResponses;

public class DtoClubResponse
{
    public Guid Id { get; set; }
    public required string ClubName { get; set; }
    public required string ClubAddress { get; set; }
    public required string ClubPhone { get; set; }
    public required string ClubDescription { get; set; }
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }

    public ICollection<DtoReviewResponse> Reviews = new List<DtoReviewResponse>();
    public ICollection<DtoClubImageResponse> ClubImages = new List<DtoClubImageResponse>();
}

public class DtoReviewResponse
{
    public Guid Id { get; set; }
    public RatingEnum Rating { get; set; }
}

public class DtoClubImageResponse
{
    public Guid Id { get; set; }
    public required string ImageUrl { get; set; }
}
