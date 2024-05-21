using System.ComponentModel.DataAnnotations;

namespace ShuttleZone.Domain.Entities;

public class Role
{
    [Key]
    public int RoleId { get; set; }
    public string? RoleName { get; set; }
    public ICollection<UserRole> Roles = new List<UserRole>();
}