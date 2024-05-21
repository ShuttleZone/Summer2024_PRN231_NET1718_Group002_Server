using ShuttleZone.Domain.Common;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities;

public class Club : BaseAuditableEntity<Club>
{
    public Guid ClubId { get; set; }
    public string? ClubName { get; set; }
    public string? ClubAddress { get; set; }
    public string? ClubPhone { get; set; }
    public string? ClubDescription { get; set; }
    public ClubStatusEnum ClubStatusEnum { get; set; }
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }
    public double MinDuration { get; set; }
    
}