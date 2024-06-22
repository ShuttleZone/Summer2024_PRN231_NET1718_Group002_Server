using ShuttleZone.Domain.Entities;
using System.Net.Mail;
using System.Net;
using ShuttleZone.Common.Settings;
using Microsoft.Extensions.Options;
using ShuttleZone.Common.Attributes;

namespace ShuttleZone.Application.Services.Email
{
    [AutoRegister]
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body, bool isBodyHtml = false)
        {
            var client = new SmtpClient(_emailSettings.MailServer, _emailSettings.MailPort)
            {
                Credentials = new NetworkCredential(_emailSettings.FromEmail, _emailSettings.Password),
                EnableSsl = true
            };

            var mailMessage = new MailMessage(_emailSettings.FromEmail!, toEmail, subject, body)
            {
                IsBodyHtml = isBodyHtml
            };
            await client.SendMailAsync(mailMessage);
        }

        public async Task SendEmailConfirmationAsync(User user, string token = "")
        {
            var encodedToken = WebUtility.UrlEncode(token);
            var returnUrl = $"{_emailSettings.ReturnUrl}?userId={user.Id}&token={encodedToken}";
            await SendEmailAsync(user.Email!, "Confirm Your Account Registration", EmailHelper.GetEmailTemplateForConfirmationEmail(returnUrl), true);
        }
    }

    public static class EmailHelper
    {
        public static string GetEmailTemplateForConfirmationEmail(string confirmationLink)
        {
            // Define parts of the email template
            string part1 = @"
        <!DOCTYPE html>
        <html lang='en'>
        <head>
            <meta charset='UTF-8'>
            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
            <title>Email Confirmation</title>
            <style>
                body {
                    font-family: Arial, sans-serif;
                    background-color: #f4f4f4;
                    margin: 0;
                    padding: 0;
                }
                .email-container {
                    max-width: 600px;
                    margin: 40px auto;
                    background-color: #ffffff;
                    border-radius: 8px;
                    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
                    padding: 20px;
                    text-align: center;
                }
                .email-header {
                    background-color: #4a90e2;
                    padding: 10px;
                    border-top-left-radius: 8px;
                    border-top-right-radius: 8px;
                }
                .email-header img {
                    width: 50px;
                    height: 50px;
                }
                .email-body {
                    padding: 20px;
                    color: #333333;
                }
                .email-body h2 {
                    color: #4a90e2;
                    margin-bottom: 20px;
                }
                .email-body p {
                    line-height: 1.6;
                    margin-bottom: 20px;
                }
                .email-button {
                    display: inline-block;
                    padding: 10px 20px;
                    background-color: #4a90e2;
                    color: #ffffff;
                    border-radius: 5px;
                    text-decoration: none;
                    font-weight: bold;
                }
                .email-footer {
                    font-size: 12px;
                    color: #777777;
                    padding: 20px;
                    border-top: 1px solid #dddddd;
                    margin-top: 20px;
                }
            </style>
        </head>
        <body>
            <div class='email-container'>
                <div class='email-header'>
                    <img src='https://vigig.blob.core.windows.net/shuttle-zone-minor/app-logofvPkrKVZJ2%25.png' alt='Logo'>
                </div>
                <div class='email-body'>
                    <h2>Email Confirmation</h2>
                    <p>
                        Thank you for registering! Please click the button below to confirm your email address and complete your registration.
                    </p>
                    <a href='";

            string part2 = confirmationLink;

            string part3 = @"' class='email-button'>Confirm Email</a>
                </div>
                <div class='email-footer'>
                    <p>If you did not create an account, no further action is required.</p>
                    <p>&copy; 2024 ShuttleZone. All rights reserved.</p>
                </div>
            </div>
        </body>
        </html>";

            // Combine the parts
            return part1 + part2 + part3;

        }
    }
}
