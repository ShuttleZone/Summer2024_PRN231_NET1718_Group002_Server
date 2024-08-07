using Microsoft.AspNetCore.Identity;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Domain.Entities;

public class User : IdentityUser<Guid>
{
    public required string Fullname { get; set; }
    public required int Gender { get; set; }
    public string? ProfilePic { get; set; }
    public UserStatusEnum UserStatusEnum { get; set; }

    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }

    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<UserContest> UserContests { get; set; } = new List<UserContest>();
    public ICollection<Club> Clubs { get; set; } = new List<Club>();
    public Guid WalletId { get; set; }
    public Wallet? Wallet { get; set; } 
    public ICollection<PackageUser> PackageUsers { get; set; } = new List<PackageUser>();
    
    public Guid? ClubId { get; set; }
    public Club? Club { get; set; }
    
}
