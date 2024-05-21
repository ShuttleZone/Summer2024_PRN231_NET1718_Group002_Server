using System.ComponentModel.DataAnnotations;

namespace ShuttleZone.Domain.Entities;

public class UserRole
{
    public Guid UserId { get; set; }
    public required User User { get; set; }

    public int RoleId { get; set; }
    public required Role Role { get; set; }
}