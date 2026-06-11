using CarRentalSystem.Business.DTOs.CarImage;
using CarRentalSystem.Entity.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Services.Abstract
{
    public interface ICarImageService
    {
        //Task<CarImageDto> AddImageAsync(CreateCarImageDto createCarImageDto );
        //Task<bool> DeleteImageAsync(int imageId);
        //Task<IEnumerable<CarImageDto>> GetImagesByCarIdAsync(int carId);
        //Task<bool> SetCoverImageAsync(int imageId, int carId);
        Task<CarImageDto> UploadAsync(int carId, IFormFile file, bool isMain = false);
        Task DeleteAsync(int imageId);
        Task SetMainAsync(int imageId);
        Task<List<CarImage>> GetByCarIdAsync(int carId);
    }
}
