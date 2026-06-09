using CarRentalSystem.DataAccess.Contexts;
using CarRentalSystem.DataAccess.Interfaces;
using CarRentalSystem.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DataAccess.Concrete
{
    public class CarImageRepository : Repository<CarImage>, ICarImageRepository
    {
        private readonly CarRentalDbContext _context;
        public CarImageRepository(CarRentalDbContext context) : base(context)        
        {
            _context = context;
        }
        public async Task<IEnumerable<CarImage>> GetImagesByCarIdAsync(int carId)
        {
            return await _context.CarImages.Where(c => c.CarId == carId).ToListAsync();
        }
        public async Task<CarImage?> GetCoverImageByCarIdAsync(int carId)
        {
           return await _context.CarImages.FirstOrDefaultAsync(c => c.CarId == carId && c.IsCoverImage);
        }       
    }
}
