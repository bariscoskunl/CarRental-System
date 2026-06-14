using CarRentalSystem.Business.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Services.Abstract
{
    public interface IAuthService
    {
        Task<AuthResultDto> LoginAsync(LoginDto loginDto);
        Task<AuthResultDto> RegisterCompanyAsync(RegisterCompanyDto registerDto);
        Task<AuthResultDto> RegisterCustomerAsync(RegisterCustomerDto registerDto);

    }
}
