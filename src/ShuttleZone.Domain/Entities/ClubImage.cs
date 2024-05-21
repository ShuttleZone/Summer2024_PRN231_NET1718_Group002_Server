using System.ComponentModel.DataAnnotations;
using ShuttleZone.Domain.Common;

namespace ShuttleZone.Domain.Entities;

public class ClubImage : BaseEntity<Guid>
{
    
    public string? ImageUrl { get; set; }
    
    public Guid? ClubId { get; set; }
    public Club? Club { get; set; }
}