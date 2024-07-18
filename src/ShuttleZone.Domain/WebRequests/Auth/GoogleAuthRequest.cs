using System.ComponentModel.DataAnnotations;

namespace ShuttleZone.Domain.WebRequests.Auth;

public class GoogleAuthRequest : OAuthRequest
{
    [Required]
    public string State { get; set; } = null!;

    [Required]
    public string Code { get; set; } = null!;

    [Required]
    public string Scope { get; set; } = null!;

    [Required]
    public string Authser { get; set; } = null!;

    [Required]
    public string Hd { get; set; } = null!;

    [Required]
    public string Prompt { get; set; } = null!;
}