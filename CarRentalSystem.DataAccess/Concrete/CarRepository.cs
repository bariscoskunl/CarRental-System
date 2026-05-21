using CarRentalSystem.DataAccess.Contexts;
using CarRentalSystem.DataAccess.Interfaces;
using CarRentalSystem.Entity.Entities;
using CarRentalSystem.Entity.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DataAccess.Concrete
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        private readonly CarRentalDbContext _context;
        public CarRepository(CarRentalDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Car>> GetCarsByBrandAsync(string brand)
        {
            return await _context.Cars.Where(a => a.Brand.ToLower() == brand.ToLower()).ToListAsync();
        }

        public async Task<IEnumerable<Car>> GetCarsByFuelTypeAsync(FuelType fuelType)
        {
            return await _context.Cars.Where(a => a.FuelType == fuelType).ToListAsync();
        }

        public async Task<IEnumerable<Car>> GetCarsByModelAsync(string model)
        {
            return await _context.Cars.Where(a => a.Model.ToLower() == model.ToLower()).ToListAsync();
        }

        public async Task<IEnumerable<Car>> GetCarsBySeatCountAsync(int seatCount)
        {
            return await _context.Cars.Where(a => a.SeatCount == seatCount).ToListAsync();
        }

        
    }
}
