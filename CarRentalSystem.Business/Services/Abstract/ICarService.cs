using CarRentalSystem.Business.DTOs.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DataAccess.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<CarDto>> GetAllCarsAsync();
        Task<CarDto?> GetCarByIdAsync(int id);
        Task<IEnumerable<CarDto>> GetAvailableCarsAsync();
        Task  CreateCarAsync(CreateCarDto dto);
        Task  UpdateCarAsync(int id, UpdateCarDto dto);
        Task<bool> DeleteCarAsync(int id);
        Task<bool> SetAvailabilityAsync(int id, bool isAvailable);
    }
}
