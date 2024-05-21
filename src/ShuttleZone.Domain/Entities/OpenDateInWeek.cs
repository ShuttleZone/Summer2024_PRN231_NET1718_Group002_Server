using System.ComponentModel.DataAnnotations;

namespace ShuttleZone.Domain.Entities;

public class OpenDateInWeek
{   
    [Key]
    public int DateId { get; set; }
    public DateOnly Date { get; set; }
    
    public Guid ClubId { get; set; }
    public Club? Club { get; set; }
}