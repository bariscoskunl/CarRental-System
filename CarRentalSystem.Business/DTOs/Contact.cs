using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.DTOs
{
    public class Contact
    {
        [Required(ErrorMessage = "İsim alanı zorunludur.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "E-posta alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Konu alanı zorunludur.")]
        public string Subject { get; set; }


        [Required(ErrorMessage = "Mesaj alanı zorunludur.")]
        public string Message { get; set; }
    }
}
