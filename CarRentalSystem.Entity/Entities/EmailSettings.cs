using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Entity.Entities
{
    public class EmailSettings
    {
        public string SmtpServer { get; set; }  // SMTP sunucu adresi
        public int Port { get; set; }  // SMTP port numarası
        public string SenderEmail { get; set; }// Gönderen e-posta adresi
        public string SenderName { get; set; }// Gönderen adı — alıcının mail kutusunda görünecek isim
        public string AppPassword { get; set; }// Gmail App Password (16 haneli, boşluklu)
        public bool UseSsl { get; set; } // SSL/TLS bağlantı modu
    }
}
