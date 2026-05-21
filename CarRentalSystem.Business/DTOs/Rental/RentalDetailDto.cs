using CarRentalSystem.Business.DTOs.Branch;
using CarRentalSystem.Business.DTOs.Car;
using CarRentalSystem.Business.DTOs.Customer;
using CarRentalSystem.Business.DTOs.Payment;
using CarRentalSystem.Entity.Enums;

namespace CarRentalSystem.Business.DTOs.Rental
{
    public class RentalDetailDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal? ExtraCharges { get; set; }
        public RentalStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        // İlişkili DTO'lar
        public CarListDto Car { get; set; } = null!;
        public CustomerSummaryDto Customer { get; set; } = null!;
        public BranchDto PickupBranch { get; set; } = null!;
        public BranchDto ReturnBranch { get; set; } = null!;
        public PaymentDto? Payment { get; set; }
    }
}
