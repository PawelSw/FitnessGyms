using AutoMapper;
using FitnessGyms.Application.ApplicationUser;
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
        private readonly IUserContext _userContext;
        public CreateFitnessGymCommandHandler(IFitnessGymRepository fitnessGymRepository, IMapper mapper, IUserContext userContext)
        {
            _mapper = mapper;
            _fitnessGymRepository = fitnessGymRepository;
            _userContext = userContext;

        }
        public async Task<Unit> Handle(CreateFitnessGymCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userContext.GetCurrentUser();
            if (currentUser == null || !currentUser.IsInRole("Owner"))
            {
                return Unit.Value;
            }
            var fitnessGym = _mapper.Map<Domain.Entities.FitnessGym>(request);
            fitnessGym.EncodeName();
            fitnessGym.CreatedById = currentUser.Id;
            await _fitnessGymRepository.Create(fitnessGym);
            return Unit.Value;
        }
    }
}
