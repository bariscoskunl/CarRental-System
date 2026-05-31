using CarRentalSystem.Business.DTOs.Rental;
using CarRentalSystem.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Services.Abstract
{
    public interface IRentalService
    {
        Task CreateAsync(RentalCreateDto dto);
        Task<RentalDetailDto> GetByIdAsync(int id);
        Task<IEnumerable<RentalDetailDto>> GetByCustomerAsync(int customerId);
        Task<IEnumerable<RentalDetailDto>> GetByCarAsync(int carId);
        Task UpdateStatusAsync(int rentalId, RentalStatus status);
        Task CancelAsync(int rentalId);
        Task<IEnumerable<RentalDetailDto>> CheckAvailabilityAsync();
        Task<decimal> CalculatePriceAsync(int rentalId);



    }
}
