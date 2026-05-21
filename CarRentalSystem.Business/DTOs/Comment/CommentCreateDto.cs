namespace CarRentalSystem.Business.DTOs.Comment
{
    public class CommentCreateDto
    {
        public string Content { get; set; } = null!;
        public int Rating { get; set; }

        public int CustomerId { get; set; }

        // İkisinden biri dolu olmalı
        public int? CarId { get; set; }
        public int? CompanyId { get; set; }
    }
}
