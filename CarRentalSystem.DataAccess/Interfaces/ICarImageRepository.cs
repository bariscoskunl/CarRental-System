using CarRentalSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DataAccess.Interfaces
{
    public interface ICarImageRepository : IRepository<CarImage>
    {
        Task<IEnumerable<CarImage>> GetImagesByCarIdAsync(int carId);
        Task<CarImage?> GetCoverImageByCarIdAsync(int carId);
    }
}
