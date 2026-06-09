using AutoMapper;
using CarRentalSystem.Business.DTOs.CarImage;
using CarRentalSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Mappings
{
    public class CarImageProfile : Profile
    {
        public CarImageProfile()
        {         
            CreateMap<CarImage, CarImageDto>().ReverseMap();
            
            CreateMap<CreateCarImageDto, CarImage>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) 
                .ForMember(dest => dest.UploadedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Car, opt => opt.Ignore());
        }
    }
}
