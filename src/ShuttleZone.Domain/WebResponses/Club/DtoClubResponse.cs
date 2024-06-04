using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.WebResponses;

public record DtoClubResponse
{
    public Guid Id { get; set; }
    public required string ClubName { get; set; }
    public required string ClubAddress { get; set; }
    public required string ClubPhone { get; set; }
    public required string ClubDescription { get; set; }
    public double MinDuration { get; set; }
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }
    public ICollection<DtoCourt> Courts { get; set; }= new List<DtoCourt>();
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

public record DtoCourt
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public CourtType CourtType { get; set; }
    public CourtStatus CourtStatus { get; set; }
    public double Price { get; set; }
}