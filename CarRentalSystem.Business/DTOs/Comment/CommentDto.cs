namespace CarRentalSystem.Business.DTOs.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }

        // Yorumu yapan müşteri
        public int CustomerId { get; set; }
        public string CustomerFullName { get; set; } = null!;

        // Hedef (biri dolu olacak)
        public int? CarId { get; set; }
        public int? CompanyId { get; set; }
    }
}
