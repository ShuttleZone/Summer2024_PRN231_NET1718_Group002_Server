using Microsoft.AspNetCore.Http;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.WebRequests.Club;

public sealed class CreateClubRequest
{
    public BasicInformation BasicInformation { get; set; } = null!;
    public Setting Settings { get; set; } = null!;
    public ICollection<string> DaysInWeekOpen { get; set; } = new List<string>();
    public string? ClubDescription { get; set; } = string.Empty;
    public ICollection<IFormFile> Files { get; set; } = new List<IFormFile>();
    public string CourtsJson { get; set; } = string.Empty;
}

public sealed class BasicInformation
{
    public string ClubName { get; set; } = String.Empty;
    public string ClubAddress { get; set; } = String.Empty;
    public string ClubPhone { get; set; } = String.Empty;
}

public sealed class Setting
{
    public DateTime OpenTime { get; set; } 
    public DateTime CloseTime { get; set; }
    public double MinDuration { get; set; }
}
public sealed class CourtRequest
{
    public required string CourtName { get; set; }
    public CourtType CourtType { get; set; }
    public CourtStatus CourtStatus { get; set; }
    public double Price { get; set; }
}