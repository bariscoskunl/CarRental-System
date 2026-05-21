using AutoMapper;
using CarRentalSystem.Business.DTOs.Car;
using CarRentalSystem.Business.Profiles;
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
    public class CarService : ICarService
    {
        private readonly CarRepository _repo;
        private readonly IMapper _mapper;

        public CarService(CarRepository repository,IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;

        }

        public async Task CreateCarAsync(CreateCarDto dto)
        {
            var car =  _mapper.Map<Car>(dto);
            await _repo.AddAsync(car);
        }

        public async Task<bool> DeleteCarAsync(int id)
        {
           var car = await _repo.GetByIdAsync(id);
            if (car == null)
                return false;
            await _repo.DeleteAsync(car);
            return true;
        }

        public async Task<IEnumerable<CarDto>> GetAllCarsAsync()
        {
            var cars = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<CarDto>>(cars);
        }

        public async Task<IEnumerable<CarDto>> GetAvailableCarsAsync()
        {
            var cars = await _repo.FindAsync(c => c.IsAvailable);
            return _mapper.Map<IEnumerable<CarDto>>(cars);
        }

        public async Task<CarDto?> GetCarByIdAsync(int id)
        {
            var car = await _repo.GetByIdAsync(id);
            return _mapper.Map<CarDto?>(car);
        }

        public async Task<bool> SetAvailabilityAsync(int id, bool isAvailable)
        {
            var car = await _repo.GetByIdAsync(id);
            if (car == null)
                return false;
            car.IsAvailable = isAvailable;
            await _repo.UpdateAsync(car);
            return true;
        }

        public async Task UpdateCarAsync(int id, UpdateCarDto dto)
        {
            var car = await _repo.GetByIdAsync(id);
            if (car == null)
                throw new KeyNotFoundException($"Car with id {id} not found");
            _mapper.Map(dto, car);
            await _repo.UpdateAsync(car);
        }
    }
}
