using AutoMapper;
using CarRentalSystem.Business.DTOs.Company;
using CarRentalSystem.Business.Services.Abstract;
using CarRentalSystem.DataAccess.Concrete;
using CarRentalSystem.DataAccess.Interfaces;
using CarRentalSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Services.Concrete
{
    public class CompanyService : ICompanyService
    {
        private readonly CompanyRepository _repository;
        private readonly IMapper _mapper;

        public CompanyService(CompanyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CompanyDto>> GetAllAsync(int? pageSize = null)
        {
           var companies = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
        }
        public async Task<CompanyCreateDto> CreateAsync(CompanyCreateDto companyCreateDto)
        {
            var company = _mapper.Map<Company>(companyCreateDto);
            await _repository.AddAsync(company);
            return companyCreateDto;
        }
        public async Task<CompanyDto> UpdateAsync(CompanyDto companyDto)
        {
            var company = await _repository.GetByIdAsync(companyDto.Id);
            if (company == null)
            { 
                throw new ArgumentException("Company not found");
            }
            _mapper.Map(companyDto, company);
            await _repository.UpdateAsync(company);
            return companyDto;
        }
        public async Task<bool> DeleteAsync(int CompanyId)
        {
            var company =await _repository.GetByIdAsync(CompanyId);
            if ( company == null)
            {
                throw new ArgumentException("Company not found");
            }
            _mapper.Map(company, company);
            await _repository.DeleteAsync(company);
            return true;
        }             

        public async Task<IEnumerable<CompanyDto>> GetCompaniesByCityAsync(string city)
        {
            var companies =await _repository.GetCompaniesByCityAsync(city);
            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
        }

        public async Task<IEnumerable<CompanyDto>> GetCompaniesByCountryAsync(string country)
        {
            var companies = await _repository.GetCompaniesByCountryAsync(country);
            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
        }
        public async Task<IEnumerable<CompanyDto>> GetCompaniesByDistrictAsync(string district)
        {
            var companies = await _repository.GetCompaniesByDistrictAsync(district);
            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
        }

        
    }
}
