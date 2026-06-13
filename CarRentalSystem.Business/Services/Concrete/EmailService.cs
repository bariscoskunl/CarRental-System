using CarRentalSystem.Business.Services.Abstract;
using CarRentalSystem.Entity.Entities;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Services.Concrete
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async Task<bool> SendEmailAsync(string toEmail, string toName, string subject, string body)
        {
            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
                mimeMessage.To.Add(new MailboxAddress(toName, toEmail));
                mimeMessage.Subject = subject;

                var bodyBuilder = new BodyBuilder { TextBody = body };
                mimeMessage.Body = bodyBuilder.ToMessageBody();

                using var client = new SmtpClient(); //Mailkit.Net.Smtp olan secilmeli.
                await client.ConnectAsync(
                    _emailSettings.SmtpServer,
                    _emailSettings.Port,
                    SecureSocketOptions.StartTls
                    );

                await client.AuthenticateAsync(
                    _emailSettings.SenderEmail,
                    _emailSettings.AppPassword
                    );

                await client.SendAsync(mimeMessage);
                await client.DisconnectAsync(true);
                return true;
            }
            catch (Exception ex)
            {
                // TODO: Üretim ortamında ILogger<EmailService> ile loglama yapılmalı
                Console.WriteLine($"E-posta gönderim hatası: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> sendActivatyionCodeAsync(string toEmail, string userName, int activationCode)
        {
            string subject = "CarRental - Hesap Aktivasyon Kodu";
            string body = $"Merhaba {userName}, \n\n" +
                $"Hesabınızı doğrulamak için aktivasyon kodunuz: {activationCode} \n\n" +
                "İyi günler dileriz.";
            return await SendEmailAsync(toEmail, userName, subject, body);
        }

        public async Task<bool> sendContactFormAsync(string senderName, string senderEmail, string subject, string message)
        {
            string adminSubject = $"İletişim Formu: {subject}";
            string adminBody = $"Gönderen: {senderName}\n" +
                               $"E-posta: {senderEmail}\n\n" +
                               $"Mesaj:\n{message}";
            return await SendEmailAsync(_emailSettings.SenderEmail, "Admin", adminSubject, adminBody);
        }      
    }
}
