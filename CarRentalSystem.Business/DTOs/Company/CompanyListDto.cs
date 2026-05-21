namespace CarRentalSystem.Business.DTOs.Company
{
    public class CompanyListDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string? CompanyImageUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
