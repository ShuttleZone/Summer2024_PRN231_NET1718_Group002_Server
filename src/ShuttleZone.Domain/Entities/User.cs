using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShuttleZone.Domain.Common;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities;

public class User : BaseAuditableEntity<Guid> 
{
    public required string Username { get; set; }
    public required string Fullname { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Phone { get; set; }
    public required int Gender { get; set; }
    public UserStatusEnum UserStatusEnum { get; set; }

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<Club> Clubs { get; set; } = new List<Club>();
    public ICollection<UserContest> UserContests { get; set; } = new List<UserContest>();
}