using AutoMapper;
using FitnessGyms.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessGyms.Application.FitnessGym.Querries.GetAllFitnessGyms
{
    public class GetAllFitnessGymsHandler : IRequestHandler<GetAllFitnessGymsQuerry, IEnumerable<FitnessGymDto>>
    {
        private readonly IFitnessGymRepository _fitnessGymRepository;
        private readonly IMapper _mapper;
        public GetAllFitnessGymsHandler(IFitnessGymRepository fitnessGymRepository, IMapper mapper)
        {
            _mapper = mapper;
            _fitnessGymRepository = fitnessGymRepository;

        }

        public async Task<IEnumerable<FitnessGymDto>> Handle(GetAllFitnessGymsQuerry request, CancellationToken cancellationToken)
        {
            var fitnessGyms = await _fitnessGymRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<FitnessGymDto>>(fitnessGyms);
            return dtos;
        }
    }
}
