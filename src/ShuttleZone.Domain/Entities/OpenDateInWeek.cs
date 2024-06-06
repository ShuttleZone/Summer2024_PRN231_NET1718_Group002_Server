using ShuttleZone.Domain.Common;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities;

public class OpenDateInWeek 
{
    public int Id { get; set; }
    public string Date { get; set; } = null!;
    public Guid ClubId { get; set; }
    public Club Club { get; set; } = null!;
}
