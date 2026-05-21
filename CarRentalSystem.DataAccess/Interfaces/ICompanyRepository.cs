using CarRentalSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DataAccess.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<IEnumerable<Company>> GetCompaniesByCityAsync(string city);
        Task<IEnumerable<Company>> GetCompaniesByCountryAsync(string country);
        Task<IEnumerable<Company>> GetCompaniesByDistrictAsync(string district);


    }
}
