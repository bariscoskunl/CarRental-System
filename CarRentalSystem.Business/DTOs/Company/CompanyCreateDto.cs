namespace CarRentalSystem.Business.DTOs.Company
{
    public class CompanyCreateDto
    {
        // Şirket sahibi
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string PersonelEmail { get; set; } = null!;
        public string PersonelPhone { get; set; } = null!;

        // Şirket
        public string CompanyName { get; set; } = null!;
        public string? Description { get; set; }
        public string TaxNumber { get; set; } = null!;

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
    }
}
