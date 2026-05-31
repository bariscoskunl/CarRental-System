using CarRentalSystem.Entity.Enums;

namespace CarRentalSystem.Business.DTOs.Payment
{
    public class PaymentCreateDto
    {
        public int RentalId { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod Method { get; set; }
    }
}
