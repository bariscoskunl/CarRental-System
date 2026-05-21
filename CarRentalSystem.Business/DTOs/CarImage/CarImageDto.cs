namespace CarRentalSystem.Business.DTOs.CarImage
{
    public class CarImageDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = null!;
        public bool IsCoverImage { get; set; }
        public DateTime UploadedAt { get; set; }
        public int CarId { get; set; }
    }
}
