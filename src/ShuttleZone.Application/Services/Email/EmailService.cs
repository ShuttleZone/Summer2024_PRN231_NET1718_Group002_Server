using ShuttleZone.Domain.Entities;
using System.Net.Mail;
using System.Net;
using ShuttleZone.Common.Settings;
using ShuttleZone.Common.Attributes;

namespace ShuttleZone.Application.Services.Email
{
    [AutoRegister]
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        public EmailService(EmailSettings emailSettings)
        {
            _emailSettings = emailSettings;
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

        public async Task SendExpirationPackageEmail(ExpirationAnnouncementEmailObject emailObject)
        {
            await SendEmailAsync(emailObject.UserEmail, "Thông báo gói đăng kí sắp hết hạn", EmailHelper.GetEmailTemplateForExpirationAnnouncement(emailObject), true);
        }

        public async Task SendEmailConfirmationAsync(User user, string token = "")
        {
            var encodedToken = WebUtility.UrlEncode(token);
            var returnUrl = $"{_emailSettings.ReturnUrl}?userId={user.Id}&token={encodedToken}";
            await SendEmailAsync(user.Email!, "Xác nhận đăng ký tài khoản của bạn", EmailHelper.GetEmailTemplateForConfirmationEmail(returnUrl), true);
        }
        
    }
    public record ExpirationAnnouncementEmailObject()
    {
        public required string UserEmail { get; set; }
        public required string RenewPackageUrl { get; set; } 
        public required string CustomerName { get; set; } 
        public required string PackageName { get; set; } 
        public required string ExpirationDay { get; set; } 
        public int RemainingDays { get; set; }
    }

    public abstract class EmailHelper
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
                    <h2>Email xác nhận</h2>
                    <p>
                        Cảm ơn bạn đã đăng ký! Vui lòng nhấp vào nút bên dưới để xác nhận địa chỉ email của bạn và hoàn tất đăng ký.
                    </p>
                    <a href='";

            string part2 = confirmationLink;

            string part3 = @"' class='email-button'>Xác nhận</a>
                </div>
                <div class='email-footer'>
                    <p>Nếu bạn không muốn tạo tài khoản thì không cần thực hiện thêm hành động nào.</p>
                    <p>&copy; 2024 ShuttleZone. All rights reserved.</p>
                </div>
            </div>
        </body>
        </html>";

            // Combine the parts
            return part1 + part2 + part3;

        }

        public static string GetEmailTemplateForExpirationAnnouncement(ExpirationAnnouncementEmailObject emailObject)
        {
            var head = @"<!DOCTYPE html>
                        <html lang=""en"">
                        <head>
                            <meta charset=""UTF-8"">
                            <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                            <title>Package Expiration Announcement</title>
                            <style>
                                body {
                                    font-family: Arial, sans-serif;
                                    background-color: #f4f4f4;
                                    margin: 0;
                                    padding: 0;
                                    color: #333;
                                }
                                .container {
                                    width: 100%;
                                    max-width: 600px;
                                    margin: 0 auto;
                                    background-color: #fff;
                                    padding: 20px;
                                    box-shadow: 0 0 10px rgba(0,0,0,0.1);
                                }
                                .header {
                                    background-color: #007BFF;
                                    color: #fff;
                                    padding: 10px 0;
                                    text-align: center;
                                }
                                .header h1 {
                                    margin: 0;
                                    font-size: 24px;
                                }
                                .content {
                                    padding: 20px;
                                }
                                .content h2 {
                                    color: #007BFF;
                                    font-size: 20px;
                                    margin-top: 0;
                                }
                                .content p {
                                    line-height: 1.6;
                                }
                                .button-container {
                                    text-align: center;
                                    margin: 20px 0;
                                }
                                .button {
                                    background-color: #007BFF;
                                    color: #fff;
                                    padding: 10px 20px;
                                    text-decoration: none;
                                    border-radius: 5px;
                                }
                                .button:hover {
                                    background-color: #0056b3;
                                }
                                .footer {
                                    text-align: center;
                                    font-size: 12px;
                                    color: #666;
                                    margin-top: 20px;
                                }
                            </style>
                        </head>";
            var body = @$"
                                <body>
                    <div class=""container"">
                        <div class=""header"">
                            <h1>Package Expiration Notice</h1>
                        </div>
                        <div class=""content"">
                            <h2>Dear {emailObject.CustomerName},</h2>
                            <p>We hope this message finds you well. This is a reminder that your package with the following details is about to expire:</p>
                            <p><strong>Package Name:</strong> {emailObject.PackageName}</p>
                            <p><strong>Expiration Date:</strong> {emailObject.ExpirationDay}</p>
                            <p>To ensure uninterrupted service, we recommend renewing your package before the expiration date. If you have any questions or need assistance with the renewal process, please do not hesitate to contact our support team.</p>
                            {((emailObject.RemainingDays == 0) ? $" <div class=\"button-container\">\n<a href=\"{emailObject.RenewPackageUrl}\" class=\"button\">Renew Now</a>\n</div>" : "")}
                            <p>Thank you for choosing our service. We look forward to continuing to serve you.</p>
                            <p>Sincerely,</p>
                            <p>ShuttleZone</p>
                        </div>
                        <div class=""footer"">
                            <p>&copy; 2024 ShuttleZone. All rights reserved.</p>
                        </div>
                    </div>
                    </body>
                    </html>
            ";
            return head + body;
        }
    }
}
