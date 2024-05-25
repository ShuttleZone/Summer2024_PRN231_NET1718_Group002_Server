using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.WebResponses;

public record DtoClubResponse
{
    public Guid Id { get; set; }
    public required string ClubName { get; set; }
    public required string ClubAddress { get; set; }
    public required string ClubPhone { get; set; }
    public required string ClubDescription { get; set; }
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }

    public ICollection<DtoReviewResponse> Reviews { get; set; } = new List<DtoReviewResponse>();
    public ICollection<DtoClubImageResponse> ClubImages { get; set; } = new List<DtoClubImageResponse>();
}

public record DtoReviewResponse
{
    public Guid Id { get; set; }
    public RatingEnum Rating { get; set; }
}

public record DtoClubImageResponse
{
    public Guid Id { get; set; }
    public required string ImageUrl { get; set; }
}
