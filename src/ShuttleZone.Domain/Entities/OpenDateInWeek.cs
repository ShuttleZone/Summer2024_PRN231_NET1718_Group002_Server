using System.ComponentModel.DataAnnotations;
using ShuttleZone.Domain.Common;

namespace ShuttleZone.Domain.Entities;

public class OpenDateInWeek : BaseEntity<OpenDateInWeek>
{   
    public DateOnly Date { get; set; }
    
    public Guid ClubId { get; set; }
    public Club? Club { get; set; }
}