using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Application.Services.Email
{
    public interface IEmailService
    {
        Task SendEmailConfirmationAsync(User user, string token);
        Task SendEmailAsync(string ToEmail, string Subject, string Body, bool IsBodyHtml = false);

        Task SendExpirationPackageEmail(ExpirationAnnouncementEmailObject emailObject);
    }
}
