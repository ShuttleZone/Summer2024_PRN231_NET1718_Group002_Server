using System.ComponentModel.DataAnnotations;
using ShuttleZone.Domain.Common;

namespace ShuttleZone.Domain.Entities;

public class Role : BaseEntity<int>
{
    public string? RoleName { get; set; }
    public ICollection<UserRole> Roles = new List<UserRole>();
}