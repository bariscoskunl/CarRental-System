namespace CarRentalSystem.Business.DTOs.Rental
{
    public class RentalCreateDto
    {
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public int PickupBranchId { get; set; }
        public int ReturnBranchId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
