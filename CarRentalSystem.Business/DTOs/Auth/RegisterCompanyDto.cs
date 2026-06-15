using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.DTOs.Auth
{
    public class RegisterCompanyDto
    {
        // Şirket sahibi
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonelEmail { get; set; }
        public string PersonelPhone { get; set; }

        // Şirket bilgileri
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string TaxNumber { get; set; }

        public string Address { get; set; }
        public string Quarter { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string CompanyPhone { get; set; }
        public string CompanyEmail { get; set; }
        public string? Website { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

}
