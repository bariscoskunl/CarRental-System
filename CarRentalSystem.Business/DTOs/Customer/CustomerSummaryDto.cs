namespace CarRentalSystem.Business.DTOs.Customer
{
    /// <summary>
    /// Rental detay sayfasında müşterinin özet bilgisini göstermek için kullanılır.
    /// </summary>
    public class CustomerSummaryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string LicenseNumber { get; set; } = null!;
    }
}
