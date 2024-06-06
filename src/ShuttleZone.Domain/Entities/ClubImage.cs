using ShuttleZone.Domain.Common;

namespace ShuttleZone.Domain.Entities;

public class ClubImage
{
    public Guid Id { get; set; }
    public required string ImageUrl { get; set; }
    
    public Guid ClubId { get; set; }
    public Club Club { get; set; } = null!;
}
