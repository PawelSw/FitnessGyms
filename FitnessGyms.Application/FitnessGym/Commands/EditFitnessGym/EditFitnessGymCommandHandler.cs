using AutoMapper;
using FitnessGyms.Application.ApplicationUser;
using FitnessGyms.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessGyms.Application.FitnessGym.Commands.EditFitnessGym
{
    public class EditFitnessGymCommandHandler : IRequestHandler<EditFitnessGymCommand>
    {
        private readonly IFitnessGymRepository _fitnessGymRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;


        public EditFitnessGymCommandHandler(IFitnessGymRepository fitnessGymRepository, IMapper mapper, IUserContext userContext)
        {
            _fitnessGymRepository = fitnessGymRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(EditFitnessGymCommand request, CancellationToken cancellationToken)
        {
           var FitnessGym = await _fitnessGymRepository.GetByEncodedName(request.EncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && FitnessGym.CreatedById == user.Id;

            if (!isEditable)
            {
                return Unit.Value;
            }

            FitnessGym.Description = request.Description;
            FitnessGym.Opinions = request.Opinions;

            FitnessGym.ContactDetails.City = request.City;
            FitnessGym.ContactDetails.PhoneNumber = request.PhoneNumber;
            FitnessGym.ContactDetails.PostalCode = request.PostalCode;
            FitnessGym.ContactDetails.Street = request.Street;

            await _fitnessGymRepository.Commit();

            return Unit.Value;
        }
    }
}
