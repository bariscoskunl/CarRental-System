// RentalRepository.cs
using CarRentalSystem.DataAccess.Concrete;
using CarRentalSystem.DataAccess.Contexts;
using CarRentalSystem.DataAccess.Interfaces;
using CarRentalSystem.Entity.Entities;
using CarRentalSystem.Entity.Enums;
using Microsoft.EntityFrameworkCore;

public class RentalRepository : Repository<Rental>, IRentalRepository
{
    private readonly CarRentalDbContext _context;

    public RentalRepository(CarRentalDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Rental?> GetByIdWithDetailsAsync(int id)
    {
        return await _context.Rentals
            .Include(r => r.Car)
            .Include(r => r.Customer)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<IEnumerable<Rental>> GetByCustomerAsync(int customerId)
    {
        return await _context.Rentals
            .Include(r => r.Car)
            .Where(r => r.CustomerId == customerId)
            .OrderByDescending(r => r.StartDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Rental>> GetByCarAsync(int carId)
    {
        return await _context.Rentals
            .Include(r => r.Customer)
            .Where(r => r.CarId == carId)
            .OrderByDescending(r => r.StartDate)
            .ToListAsync();
    }

    // CheckAvailabilityAsync için — aktif/bekleyen kiralıkları getirir
    public async Task<IEnumerable<Rental>> GetActiveRentalsAsync()
    {
        return await _context.Rentals
            .Include(r => r.Car)
            .Include(r => r.Customer)
            .Where(r => r.Status == RentalStatus.Active ||
                        r.Status == RentalStatus.Pending)
            .ToListAsync();
    }

    // Aynı araç için çakışan tarih aralığı kontrolü (CalculatePrice & Create için yardımcı)
    public async Task<bool> HasOverlapAsync(int carId, DateTime startDate, DateTime endDate, int? excludeRentalId = null)
    {
        return await _context.Rentals
            .Where(r => r.CarId == carId
                     && r.Id != excludeRentalId
                     && r.Status != RentalStatus.Cancelled
                     && r.StartDate < endDate
                     && r.EndDate > startDate)
            .AnyAsync();
    }
}