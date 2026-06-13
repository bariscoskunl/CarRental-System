using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Services.Abstract
{
    public interface IEmailService
    {
        // Genel amaçlı e-posta gönderimi
        Task<bool> SendEmailAsync(string toEmail, string toName, string subject, string body);

        // Kayıt sırasında aktivasyon kodu gönderimi
        Task<bool> sendActivatyionCodeAsync(string toEmail, string userName, int activationCode);

        // "Bize Ulaşın" formundan gelen mesajı admin'e iletir
        Task<bool> sendContactFormAsync(string senderName, string senderEmail, string subject, string message);
    }
}
