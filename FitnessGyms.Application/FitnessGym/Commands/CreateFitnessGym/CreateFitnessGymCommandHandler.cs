using AutoMapper;
using FitnessGyms.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessGyms.Application.FitnessGym.Commands.CreateFitnessGym
{
    public class CreateFitnessGymCommandHandler : IRequestHandler<CreateFitnessGymCommand>
    {
        private readonly IFitnessGymRepository _fitnessGymRepository;
        private readonly IMapper _mapper;
        public CreateFitnessGymCommandHandler(IFitnessGymRepository fitnessGymRepository, IMapper mapper) 
        {
           _mapper = mapper;
           _fitnessGymRepository = fitnessGymRepository;
        
        }
        public async Task<Unit> Handle(CreateFitnessGymCommand request, CancellationToken cancellationToken)
        {
            var fitnessGym = _mapper.Map<Domain.Entities.FitnessGym>(request);
            fitnessGym.EncodeName();
            await _fitnessGymRepository.Create(fitnessGym);
            return Unit.Value;
        }
    }
}
