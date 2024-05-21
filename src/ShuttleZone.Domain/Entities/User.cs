using System.ComponentModel.DataAnnotations;
using ShuttleZone.Domain.Common;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities;

public class User : BaseAuditableEntity<User>
{
    [Key]
    public Guid UserId { get; set; }
    public string? Username { get; set; }
    public string? Fullname { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Phone { get; set; }
    public int Gender { get; set; }
    public UserStatusEnum UserStatusEnum { get; set; }

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

}