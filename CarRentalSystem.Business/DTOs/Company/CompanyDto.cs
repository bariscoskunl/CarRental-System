using CarRentalSystem.Business.DTOs.Branch;

namespace CarRentalSystem.Business.DTOs.Company
{
    public class CompanyDto
    {
        public int Id { get; set; }

        // Şirket sahibi
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string PersonelEmail { get; set; } = null!;
        public string PersonelPhone { get; set; } = null!;
        public string? ProfileImageUrl { get; set; }

        // Şirket bilgileri
        public string CompanyName { get; set; } = null!;
        public string? Description { get; set; }
        public string TaxNumber { get; set; } = null!;
        public string? CompanyImageUrl { get; set; }

        // Adres
        public string Address { get; set; } = null!;
        public string Quarter { get; set; } = null!;
        public string District { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;

        // İletişim
        public string CompanyPhone { get; set; } = null!;
        public string CompanyEmail { get; set; } = null!;
        public string? Website { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // İlişkili şubeler
        public List<BranchDto> Branches { get; set; } = new();
    }
}
