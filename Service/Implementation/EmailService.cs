using Data.Helpers;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class EmailService :IEmailService
    {
        private readonly EmailSettings _emailSettings;
        public EmailService(EmailSettings emailSettings) 
        {
            _emailSettings = emailSettings;
        }

        public async Task<string> SendEmail(string Email, string Message, string? reason)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress("Future Team", _emailSettings.FromEmail));
                email.To.Add(new MailboxAddress("", Email));
                email.Subject = reason ?? "No Subject";
                email.Body = new TextPart(TextFormat.Html) { Text = Message };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_emailSettings.FromEmail, _emailSettings.Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);

                return "Success";
            }
            catch (Exception ex)
            {
                return $"Failed: {ex.Message}";
            }
       //     return "Failed";
            
        }
    }

}
