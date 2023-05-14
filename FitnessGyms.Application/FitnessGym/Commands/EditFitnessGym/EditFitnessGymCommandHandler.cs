using AutoMapper;
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

        public EditFitnessGymCommandHandler(IFitnessGymRepository fitnessGymRepository, IMapper mapper)
        {
            _fitnessGymRepository = fitnessGymRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(EditFitnessGymCommand request, CancellationToken cancellationToken)
        {
           var FitnessGym = await _fitnessGymRepository.GetByEncodedName(request.EncodedName);
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
