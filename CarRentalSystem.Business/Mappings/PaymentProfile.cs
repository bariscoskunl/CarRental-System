using AutoMapper;
using CarRentalSystem.Business.DTOs.Payment;
using CarRentalSystem.Entity.Entities;
using CarRentalSystem.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Mappings
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentCreateDto, Payment>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Rental, opt => opt.Ignore())
            .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => PaymentStatus.Pending))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.PaidAt, opt => opt.Ignore())
            .ForMember(dest => dest.TransactionId, opt => opt.Ignore());

            // Payment -> PaymentDto
            CreateMap<Payment, PaymentDto>();

            // PaymentDto -> Payment
            CreateMap<PaymentDto, Payment>()
                .ForMember(dest => dest.Rental, opt => opt.Ignore());
        }
    }
}
