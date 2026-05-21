using CarRentalSystem.Business.DTOs.Car;
using CarRentalSystem.Business.DTOs.Customer;
using CarRentalSystem.Entity.Enums;

namespace CarRentalSystem.Business.DTOs.Rental
{
    public class RentalListDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public RentalStatus Status { get; set; }

        // Araç özeti
        public string CarBrand { get; set; } = null!;
        public string CarModel { get; set; } = null!;
        public string? CarCoverImageUrl { get; set; }

        // Müşteri özeti
        public string CustomerFullName { get; set; } = null!;
    }
}
