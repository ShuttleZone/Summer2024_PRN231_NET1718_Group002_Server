using ShuttleZone.Domain.Enums;
using ShuttleZone.Domain.WebResponses.ShuttleZoneUser;

namespace ShuttleZone.Domain.WebResponses;

public record DtoClubResponse
{
    public Guid Id { get; set; }
    public required string ClubName { get; set; }
    public required string ClubAddress { get; set; }
    public required string ClubPhone { get; set; }
    public required string ClubDescription { get; set; }
    public ClubStatusEnum ClubStatusEnum { get; set; }

    public double MinDuration { get; set; }
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }
    public string OwnerName { get; set; } = null!;
    public ICollection<DtoCourt> Courts { get; set; }= new List<DtoCourt>();
    public ICollection<DtoReviewResponse> Reviews { get; set; } = new List<DtoReviewResponse>();
    public ICollection<DtoClubImageResponse> ClubImages { get; set; } = new List<DtoClubImageResponse>();
    public ICollection<DtoOpenDateInWeek> OpenDateInWeeks { get; set; } = new List<DtoOpenDateInWeek>();
    public ICollection<DtoStaffProfile> Staffs { get; set; } = new List<DtoStaffProfile>();
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

public record DtoOpenDateInWeek
{
    public int Id { get; set; }
    public string Date { get; set; } = null!;
}   
public record DtoStaffProfile
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public int Gender { get; set; }
    public string ProfileImage { get; set; } = null!;
}