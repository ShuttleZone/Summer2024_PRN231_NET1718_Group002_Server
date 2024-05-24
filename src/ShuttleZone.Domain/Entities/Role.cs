using Microsoft.AspNetCore.Identity;

namespace ShuttleZone.Domain.Entities;

public class Role : IdentityRole<Guid>
{
    public ICollection<UserRole> Roles = new List<UserRole>();
}
