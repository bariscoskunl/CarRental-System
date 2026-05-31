using CarRentalSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DataAccess.Interfaces
{
    public interface IRentalRepository
    {
        Task<Rental?> GetByIdWithDetailsAsync(int id);
        Task<IEnumerable<Rental>> GetByCustomerAsync(int customerId);
        Task<IEnumerable<Rental>> GetByCarAsync(int carId);
        Task<IEnumerable<Rental>> GetActiveRentalsAsync();
        Task<bool> HasOverlapAsync(int carId, DateTime startDate, DateTime endDate, int? excludeRentalId = null);

    }
}
