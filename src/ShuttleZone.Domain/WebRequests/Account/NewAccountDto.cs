using System.ComponentModel.DataAnnotations;

namespace ShuttleZone.Domain.WebRequests.Account;

public class NewAccountDto
{
    [Required]
    public required string Fullname { get; set; }
    [Required]
    public string? Username { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    
    public  string? Token { get; set; }
}