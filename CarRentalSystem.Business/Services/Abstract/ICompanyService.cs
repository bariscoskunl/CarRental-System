using CarRentalSystem.Business.DTOs.Company;
using CarRentalSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Services.Abstract
{
    public interface ICompanyService 
    {

        Task<CompanyCreateDto> CreateAsync(CompanyCreateDto companyCreateDto);
        Task<IEnumerable<CompanyDto>> GetAllAsync (int? pageSize = null);
        Task<CompanyDto> UpdateAsync (CompanyDto companyDto);
        Task<bool> DeleteAsync(int CompanyId);
        Task<IEnumerable<CompanyDto>> GetCompaniesByCityAsync(string city);
        Task<IEnumerable<CompanyDto>> GetCompaniesByCountryAsync(string country);
        Task<IEnumerable<CompanyDto>> GetCompaniesByDistrictAsync(string district);


    }
}
