using CarRentalSystem.Entity.Enums;

namespace CarRentalSystem.Business.DTOs.Car
{
    public class CarListDto
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public decimal DailyPrice { get; set; }
        public CarCategory Category { get; set; }
        public GearType GearType { get; set; }
        public FuelType FuelType { get; set; }
        public int SeatCount { get; set; }
        public bool IsAvailable { get; set; }
        public CarStatus Status { get; set; }
        public string? CoverImageUrl { get; set; }

        // Şirket özeti
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;
    }
}
