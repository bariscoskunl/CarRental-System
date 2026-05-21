using CarRentalSystem.Business.DTOs.Comment;
using CarRentalSystem.Business.DTOs.CarImage;
using CarRentalSystem.Entity.Enums;

namespace CarRentalSystem.Business.DTOs.Car
{
    public class CarDetailDto
    {
        public int Id { get; set; }
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
        public bool IsAvailable { get; set; }
        public DateTime? NextAvailableDate { get; set; }
        public CarStatus Status { get; set; }

        // Şirket
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = null!;

        // İlişkili koleksiyonlar
        public List<CarImageDto> Images { get; set; } = new();
        public List<CommentDto> Comments { get; set; } = new();
    }
}
