
using AutoMapper;
using FitnessGyms.Application.FitnessGym;
using FitnessGyms.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessGyms.Application.Services
{
    public class FitnessGymService : IFitnessGymService
    {
        private readonly IFitnessGymRepository _fitnessGymRepository;
        private readonly IMapper _mapper;
        public FitnessGymService(IFitnessGymRepository fitnessGymRepository, IMapper mapper)
        {
           _fitnessGymRepository = fitnessGymRepository;
            _mapper = mapper;
        }
        public async Task Create(FitnessGymDto fitnessGymDto)
        {
            var fitnessGym = _mapper.Map<Domain.Entities.FitnessGym>(fitnessGymDto);
            fitnessGym.EncodeName();
            await _fitnessGymRepository.Create(fitnessGym);
        }
    }
}
