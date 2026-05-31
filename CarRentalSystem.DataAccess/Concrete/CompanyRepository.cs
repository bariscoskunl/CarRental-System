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
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly CarRentalDbContext _context;
        public CompanyRepository(CarRentalDbContext context) : base(context)
        {
            _context = context;    
        }

        public async Task<IEnumerable<Company>> GetCompaniesByCityAsync(string city)
        {
            return await _context.Companies.Where(c => c.City.ToLower() == city.ToLower()).ToListAsync();
        }

        public async Task<IEnumerable<Company>> GetCompaniesByCountryAsync(string country)
        {
            return await _context.Companies.Where(c => c.Country.ToLower() == country.ToLower()).ToListAsync();
        }

        public async Task<IEnumerable<Company>> GetCompaniesByDistrictAsync(string district)
        {
            return await _context.Companies.Where(c => c.District.ToLower() == district.ToLower()).ToListAsync();
        }
    }
}
