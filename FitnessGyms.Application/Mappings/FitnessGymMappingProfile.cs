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
        }
    }
}
