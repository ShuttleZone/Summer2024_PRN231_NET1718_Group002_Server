using System.ComponentModel.DataAnnotations;
using ShuttleZone.Domain.Common;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities;

public class OpenDateInWeek : BaseEntity<int>
{
    public List<DateInWeekEnum> Date { get; set; } = new List<DateInWeekEnum>();
    public Guid ClubId { get; set; }
    public Club? Club { get; set; }
}