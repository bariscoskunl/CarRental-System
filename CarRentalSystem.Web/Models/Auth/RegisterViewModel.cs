using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Web.Models.Auth
{
    public enum AccountType
    {
        Customer = 1,
        Company = 2
    }
    public class RegisterViewModel
    {
        [Required]
        public AccountType AccountType { get; set; }

        // ---------- ApplicationUser'a gidecek ortak alanlar ----------
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Surname { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, Phone]
        public string Phone { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public IFormFile? ProfileImage { get; set; }

        // ---------- Customer'a özel alanlar (AccountType == Customer ise dolu) ----------
        public string? LicenseNumber { get; set; }
        public DateTime? LicenseExpireDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        // ---------- Company'e özel alanlar (AccountType == Company ise dolu) ----------
        public string? CompanyName { get; set; }
        public string? Description { get; set; }
        public string? TaxNumber { get; set; }
        public IFormFile? CompanyImage { get; set; }

        public string? CompanyAddress { get; set; }
        public string? Quarter { get; set; }
        public string? District { get; set; }
        public string? CompanyCity { get; set; }
        public string? CompanyCountry { get; set; }

        public string? CompanyPhone { get; set; }
        public string? CompanyEmail { get; set; }
        public string? Website { get; set; }
    }
}
