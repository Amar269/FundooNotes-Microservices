using System;
using System.Collections.Generic;
using System.Text;
using UserService.Application.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Options;
using UserService.Infrastructure.Configurations;
using System.IO;

namespace UserService.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendWelcomeEmailAsync(string toEmail, string userName)
        {
            var templatePath = Path.Combine( Directory.GetCurrentDirectory() , "..","UserService.Infrastructure","EmailTemplates",
                              
                               "WelcomeTemplate.html");

            var htmlBody = await File.ReadAllTextAsync(templatePath);

            htmlBody = htmlBody.Replace("{{UserName}}", userName);


            // SMTP Connect

            var email = new MimeMessage();

            email.From.Add(
                new MailboxAddress(
                    _emailSettings.SenderName,
                    _emailSettings.SenderEmail));

            email.To.Add(MailboxAddress.Parse(toEmail));

            email.Subject = "Welcome To Fundoo Notes 🚀";

            email.Body = new BodyBuilder
            {
                HtmlBody = htmlBody
            }.ToMessageBody();

            // send Mail
            using var smtp = new SmtpClient();

            await smtp.ConnectAsync(
                _emailSettings.SmtpServer,
                _emailSettings.Port,
                MailKit.Security.SecureSocketOptions.StartTls);

            await smtp.AuthenticateAsync(
                _emailSettings.SenderEmail,
                _emailSettings.Password);

            await smtp.SendAsync(email);

            await smtp.DisconnectAsync(true);
        }


    }
}
