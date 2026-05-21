using CarRentalSystem.Entity.Enums;

namespace CarRentalSystem.Business.DTOs.Rental
{
    /// <summary>
    /// Admin panelinden kiralama durumunu güncellemek için kullanılır.
    /// </summary>
    public class RentalUpdateStatusDto
    {
        public int Id { get; set; }
        public RentalStatus Status { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public decimal? ExtraCharges { get; set; }
    }
}
