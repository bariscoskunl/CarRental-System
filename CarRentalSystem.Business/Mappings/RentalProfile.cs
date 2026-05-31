using AutoMapper;
using CarRentalSystem.Business.DTOs.Rental;
using CarRentalSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Mappings
{
    public class RentalProfile : Profile
    {
        public RentalProfile()
        {
            CreateMap<RentalCreateDto, Rental>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Customer, opt => opt.Ignore())
                .ForMember(dest => dest.Car, opt => opt.Ignore())
                .ForMember(dest => dest.PickupBranch, opt => opt.Ignore())
                .ForMember(dest => dest.ReturnBranch, opt => opt.Ignore())
                .ForMember(dest => dest.ActualReturnDate, opt => opt.Ignore())
                .ForMember(dest => dest.TotalPrice, opt => opt.Ignore())
                .ForMember(dest => dest.ExtraCharges, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Payment, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));

            // Rental (Entity) → RentalDetailDto
            CreateMap<Rental, RentalDetailDto>()
                .ForMember(dest => dest.Car, opt => opt.MapFrom(src => src.Car))
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.PickupBranch, opt => opt.MapFrom(src => src.PickupBranch))
                .ForMember(dest => dest.ReturnBranch, opt => opt.MapFrom(src => src.ReturnBranch))
                .ForMember(dest => dest.Payment, opt => opt.MapFrom(src => src.Payment));






        }
    }
}
