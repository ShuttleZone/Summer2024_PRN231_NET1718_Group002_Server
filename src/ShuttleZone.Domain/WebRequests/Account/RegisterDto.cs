using System.ComponentModel.DataAnnotations;

namespace ShuttleZone.Domain.WebRequests.Account;

public class RegisterDto
{
    [Required]
    public required string Fullname { get; set; }
    [Required]
    public required string Username { get; set; }
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    [Required]
    [Phone]
    public string? PhoneNumber { get; set; }
    [Required]
    public required string Password { get; set; }
}