using System.ComponentModel.DataAnnotations;

namespace ShuttleZone.Domain.WebRequests;

public record ChangePasswordRequest
(
    [Required]
    string CurrentPassword,
    [Required]
    string NewPassword
);
