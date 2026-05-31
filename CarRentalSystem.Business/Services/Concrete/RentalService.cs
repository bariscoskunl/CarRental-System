using AutoMapper;
using CarRentalSystem.Business.DTOs.Rental;
using CarRentalSystem.Business.Services.Abstract;
using CarRentalSystem.Entity.Entities;
using CarRentalSystem.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Services.Concrete
{
    public class RentalService : IRentalService
    {
        private readonly RentalRepository _repo;
        private readonly IMapper _mapper;

        public RentalService(RentalRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<decimal> CalculatePriceAsync(int rentalId)
        {
            var rental = await _repo.GetByIdAsync(rentalId);
            var total = rental.TotalPrice + rental.ExtraCharges.GetValueOrDefault(0);
            return total;
        }

        public async Task CancelAsync(int rentalId)
        {
            var rental = await _repo.GetByIdAsync(rentalId);
            if (rental == null)
                throw new Exception("Rental not found");
            if (rental.Status != RentalStatus.Cancelled)
            {
                rental.Status = RentalStatus.Cancelled;
            }
            if (rental.Status == RentalStatus.Cancelled)
            {
                throw new Exception("Rental is already cancelled");
            }
        }

        public async Task<IEnumerable<RentalDetailDto>> CheckAvailabilityAsync()
        {
            var rentals = await _repo.GetAllAsync();
            var results = rentals.Where(r => r.Status == RentalStatus.Active || r.Status == RentalStatus.Completed|| r.Status == RentalStatus.Cancelled )
                .Select(r => _mapper.Map<RentalDetailDto>(r));
            return results;
        }

        public async Task CreateAsync(RentalCreateDto dto)
        {
            var rental = _mapper.Map<Rental>(dto);
            await _repo.AddAsync(rental);

        }

        public async Task<IEnumerable<RentalDetailDto>> GetByCarAsync(int carId)
        {
            var rentals = await _repo.FindAsync(r => r.CarId == carId);
            var result = _mapper.Map<IEnumerable<RentalDetailDto>>(rentals);
            return result;
        }

        public async Task<IEnumerable<RentalDetailDto>> GetByCustomerAsync(int customerId)
        {
            var rentals = await _repo.FindAsync(r => r.CustomerId == customerId);
            var result = _mapper.Map<IEnumerable<RentalDetailDto>>(rentals);
            return result;
        }

        public async Task<RentalDetailDto> GetByIdAsync(int id)
        {
            var rental = await _repo.GetByIdAsync(id);
            if (rental == null)
                throw new Exception("Rental not found");
            var result = _mapper.Map<RentalDetailDto>(rental);
            return result;
        }

        public async Task UpdateStatusAsync(int rentalId, RentalStatus status)
        {
            var rental = await _repo.GetByIdAsync(rentalId);
            rental.Status = status;
            await _repo.UpdateAsync(rental);
        }
    }
}
