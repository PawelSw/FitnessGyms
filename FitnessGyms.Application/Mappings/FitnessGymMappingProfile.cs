using AutoMapper;
using FitnessGyms.Application.FitnessGym;
using FitnessGyms.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessGyms.Application.Mappings
{
    public class FitnessGymMappingProfile : Profile
    {
       public FitnessGymMappingProfile() 
        {
            CreateMap<FitnessGymDto, Domain.Entities.FitnessGym>()
                .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new FitnessGymContactDetails()
                {
                    City = src.City,
                    PhoneNumber = src.PhoneNumber,
                    PostalCode = src.PostalCode,
                    Street = src.Street,
                }));

            CreateMap<Domain.Entities.FitnessGym, FitnessGymDto>()
             .ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
             .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.ContactDetails.City))
             .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode))
             .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber));

        }
    }
}
