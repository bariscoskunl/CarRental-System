using CarRentalSystem.Business.DTOs.Auth;
using CarRentalSystem.Business.Services.Abstract;
using CarRentalSystem.DataAccess.Interfaces;
using CarRentalSystem.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Services.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IPasswordHasher<Customer> _customerHasher;
        private readonly IPasswordHasher<Company> _companyHasher;

        public AuthService(ICustomerRepository customerRepository, ICompanyRepository companyRepository,IPasswordHasher<Customer> customerHasher,IPasswordHasher<Company> companyHasher)
        {
            _customerRepository = customerRepository;
            _companyRepository = companyRepository;
            _customerHasher = customerHasher;
            _companyHasher = companyHasher;
        }

        public async Task<AuthResultDto> LoginAsync(LoginDto dto)
        {
            var customer = await _customerRepository.GetByEmailAsync(dto.Email);
            if (customer != null)
            {
                var verify = _customerHasher.VerifyHashedPassword(customer, customer.PasswordHash, dto.Password);
                if (verify == PasswordVerificationResult.Failed)
                    return AuthResultDto.Fail("E-posta veya şifre hatalı.");

                if (!customer.IsActive)
                    return AuthResultDto.Fail("Hesabınız aktif değil.");

                return AuthResultDto.SuccessResult(customer.Id, UserType.Customer, customer.Email, $"{customer.Name} {customer.Surname}", customer.ProfileImageUrl);
            }
            var company = await _companyRepository.GetByEmailAsync(dto.Email);
            if (company != null)
            {
                var verify = _companyHasher.VerifyHashedPassword(company, company.PasswordHash, dto.Password);
                if (verify == PasswordVerificationResult.Failed)
                    return AuthResultDto.Fail("E-posta veya şifre hatalı.");

                if (!company.IsActive)
                    return AuthResultDto.Fail("Hesabınız aktif değil.");

                return AuthResultDto.SuccessResult(company.Id, UserType.Company, company.PersonelEmail, company.CompanyName, company.ProfileImageUrl);
            }

            return AuthResultDto.Fail("E-posta veya şifre hatalı.");


        }

        public async Task<AuthResultDto> RegisterCompanyAsync(RegisterCompanyDto dto)
        {
            if (dto.Password != dto.ConfirmPassword)
                return AuthResultDto.Fail("Şifreler eşleşmiyor.");

            var emailTaken = await _companyRepository.EmailExistsAsync(dto.PersonelEmail)
                          || await _customerRepository.EmailExistsAsync(dto.PersonelEmail);

            if (emailTaken)
                return AuthResultDto.Fail("Bu e-posta adresi zaten kullanılıyor.");

            var company = new Company
            {
                Name = dto.Name,
                Surname = dto.Surname,
                PersonelEmail = dto.PersonelEmail,
                PersonelPhone = dto.PersonelPhone,
                CompanyName = dto.CompanyName,
                Description = dto.Description,
                TaxNumber = dto.TaxNumber,
                Address = dto.Address,
                Quarter = dto.Quarter,
                District = dto.District,
                City = dto.City,
                Country = dto.Country,
                CompanyPhone = dto.CompanyPhone,
                CompanyEmail = dto.CompanyEmail,
                Website = dto.Website,
                CreatedAt = DateTime.Now,
                IsActive = true
            };
            company.PasswordHash = _companyHasher.HashPassword(company, dto.Password);
            await _companyRepository.AddAsync(company);
            return AuthResultDto.SuccessResult(company.Id, UserType.Company, company.PersonelEmail, company.CompanyName);



        }

        public async Task<AuthResultDto> RegisterCustomerAsync(RegisterCustomerDto dto)
        {
            if(dto.Password != dto.ConfirmPassword)
                return AuthResultDto.Fail("Şifreler eşleşmiyor.");
            var emailTaken = await _customerRepository.EmailExistsAsync(dto.Email) || await _companyRepository.EmailExistsAsync(dto.Email);
            if (emailTaken)
                return AuthResultDto.Fail("Bu e-posta adresi zaten kullanılıyor.");

            var customer = new Customer
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address,
                City = dto.City,
                Country = dto.Country,
                LicenseNumber = dto.LicenseNumber,
                LicenseExpireDate = dto.LicenseExpireDate,
                BirthDate = dto.BirthDate,
                RegisterDate = DateTime.Now,
                IsActive = true
            };
            customer.PasswordHash = _customerHasher.HashPassword(customer, dto.Password);
            await _customerRepository.AddAsync(customer);

            return AuthResultDto.SuccessResult(customer.Id, UserType.Customer, customer.Email, $"{customer.Name} {customer.Surname}");
        }
    }
}
