using CarRentalSystem.Business.DTOs.Payment;
using CarRentalSystem.Entity.Entities;
using CarRentalSystem.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Services.Abstract
{
    public interface IPaymentService
    {
        Task CreateAsync(PaymentCreateDto dto);
        Task UpdateStatusAsync(int paymentId, PaymentStatus status);
        Task<IEnumerable<PaymentDto>> GetByRentalAsync(int rentalId);
        Task RefundAsync (int id);

    }
}
