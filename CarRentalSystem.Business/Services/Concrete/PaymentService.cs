using AutoMapper;
using CarRentalSystem.Business.DTOs.Payment;
using CarRentalSystem.Business.Services.Abstract;
using CarRentalSystem.DataAccess.Concrete;
using CarRentalSystem.Entity.Entities;
using CarRentalSystem.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Services.Concrete
{
    public class PaymentService : IPaymentService
    {
        private readonly Repository<Payment> _repo;
        private readonly IMapper _mapper;

        public PaymentService(Repository<Payment> repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateAsync(PaymentCreateDto dto)
        {
            var payment = _mapper.Map<Payment>(dto);
            await _repo.AddAsync(payment);

        }

        public async Task<IEnumerable<PaymentDto>> GetByRentalAsync(int rentalId)
        {
            var payments = await _repo.FindAsync(p => p.RentalId == rentalId);
            return payments.Select(p => _mapper.Map<PaymentDto>(p));
        }

        public async Task RefundAsync(int id)
        {
            var payment = await _repo.FindAsync(p => p.Id == id);
            if (payment == null)
                throw new Exception("Payment not found for the given rental.");
            var result = _mapper.Map<Payment>(payment);
            result.Status = PaymentStatus.Refunded;
            await _repo.UpdateAsync(result);    
        }

        public async Task UpdateStatusAsync(int paymentId, PaymentStatus status)
        {
            var payment = await _repo.FindAsync(p => p.Id == paymentId);
            if (payment == null)
                throw new Exception("Payment not found for the given rental.");
            var result = _mapper.Map<Payment>(payment);
            result.Status = status;
            await _repo.UpdateAsync(result);
        }
    }
}
