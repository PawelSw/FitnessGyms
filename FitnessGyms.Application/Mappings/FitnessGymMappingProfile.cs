using AutoMapper;
using FitnessGyms.Application.ApplicationUser;
using FitnessGyms.Application.FitnessGym;
using FitnessGyms.Application.FitnessGym.Commands.EditFitnessGym;
using FitnessGyms.Domain.Entities;

namespace FitnessGyms.Application.Mappings
{
    public class FitnessGymMappingProfile : Profile
    {
       public FitnessGymMappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();
            CreateMap<FitnessGymDto, Domain.Entities.FitnessGym>()
                .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new FitnessGymContactDetails()
                {
                    City = src.City,
                    PhoneNumber = src.PhoneNumber,
                    PostalCode = src.PostalCode,
                    Street = src.Street,
                }));

            CreateMap<Domain.Entities.FitnessGym, FitnessGymDto>()
             .ForMember(dto => dto.IsEditable, opt => opt.MapFrom(src => user != null && src.CreatedById == user.Id))
             .ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
             .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.ContactDetails.City))
             .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode))
             .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber));

            CreateMap<FitnessGymDto, EditFitnessGymCommand>();

        }
    }
}
