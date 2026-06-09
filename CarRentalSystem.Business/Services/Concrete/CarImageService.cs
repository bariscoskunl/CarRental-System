using AutoMapper;
using CarRentalSystem.Business.DTOs.CarImage;
using CarRentalSystem.Business.Services.Abstract;
using CarRentalSystem.DataAccess.Interfaces;
using CarRentalSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Services.Concrete
{
    public class CarImageService : ICarImageService
    {
        private readonly IMapper _mapper;
        private readonly ICarImageRepository _carImageRepository;

        public CarImageService(IMapper mapper, ICarImageRepository carImageRepository)
        {
            _mapper = mapper;
            _carImageRepository = carImageRepository;
        }
        public async Task<CarImageDto> AddImageAsync(CreateCarImageDto createCarImageDto)
        {
            if (createCarImageDto.IsCoverImage)
            { 
                var existingCoverImage = await _carImageRepository.GetCoverImageByCarIdAsync(createCarImageDto.CarId);
                if (existingCoverImage != null)
                {
                    existingCoverImage.IsCoverImage = false;
                    await _carImageRepository.UpdateAsync(existingCoverImage);
                }
            }

            var CarImage = _mapper.Map<CarImage>(createCarImageDto);
            CarImage.UploadedAt = DateTime.UtcNow;
            await _carImageRepository.AddAsync(CarImage);
            return _mapper.Map<CarImageDto>(CarImage);
        }

        public async Task<bool> DeleteImageAsync(int imageId)
        {
            var image = await _carImageRepository.GetByIdAsync(imageId);
            if (image == null)
            {
                return false;
            }
            await _carImageRepository.DeleteAsync(image);
            return true;
        }

        public async Task<IEnumerable<CarImageDto>> GetImagesByCarIdAsync(int carId)
        {
            var images =await _carImageRepository.GetImagesByCarIdAsync(carId);
            return _mapper.Map<IEnumerable<CarImageDto>>(images);
        }

        public async Task<bool> SetCoverImageAsync(int imageId, int carId)
        {
            var newCover = await _carImageRepository.GetByIdAsync(imageId);
            if (newCover == null || newCover.CarId != carId)
            { 
                return false;
            }
            var oldCover = await _carImageRepository.GetCoverImageByCarIdAsync(carId);
            if (oldCover != null)
            {
                oldCover.IsCoverImage = false;
                await _carImageRepository.UpdateAsync(oldCover);
            }
            newCover.IsCoverImage = true;
            await _carImageRepository.UpdateAsync(newCover);
            return true;
        }
    }
}
