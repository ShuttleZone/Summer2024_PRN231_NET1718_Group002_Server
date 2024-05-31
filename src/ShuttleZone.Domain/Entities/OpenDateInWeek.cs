using ShuttleZone.Domain.Common;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities;

public class OpenDateInWeek : BaseEntity<int>
{
    public string Date { get; set; } = null!;
    public required Guid ClubId { get; set; }
    public Club? Club { get; set; }
}
