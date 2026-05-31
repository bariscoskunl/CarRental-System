using CarRentalSystem.Entity.Enums;

namespace CarRentalSystem.Business.DTOs.Payment
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int RentalId { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? PaidAt { get; set; }
        public string? TransactionId { get; set; }
    }
}
