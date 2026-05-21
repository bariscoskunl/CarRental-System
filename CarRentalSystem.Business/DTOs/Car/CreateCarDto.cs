using CarRentalSystem.Entity.Enums;

namespace CarRentalSystem.Business.DTOs.Car
{
    public class CreateCarDto
    {
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public int Kilometers { get; set; }
        public string PlateNumber { get; set; } = null!;

        public GearType GearType { get; set; }
        public CarCategory Category { get; set; }
        public FuelType FuelType { get; set; }
        public int EngineCC { get; set; }
        public int SeatCount { get; set; }

        public decimal DailyPrice { get; set; }

        public int CompanyId { get; set; }
    }
}
