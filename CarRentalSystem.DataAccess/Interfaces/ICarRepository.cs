using CarRentalSystem.DataAccess.Concrete;
using CarRentalSystem.Entity.Entities;
using CarRentalSystem.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DataAccess.Interfaces
{
    public interface ICarRepository : IRepository<Car>
    {
        Task<IEnumerable<Car>> GetCarsByBrandAsync(string brand);
        Task<IEnumerable<Car>> GetCarsByModelAsync(string model);
        Task<IEnumerable<Car>> GetCarsByFuelTypeAsync(FuelType fuelType);
        Task<IEnumerable<Car>> GetCarsBySeatCountAsync(int seatCount);



    }
}
