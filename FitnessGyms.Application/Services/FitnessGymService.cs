using FitnessGyms.Domain.Entities;
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
        public FitnessGymService(IFitnessGymRepository fitnessGymRepository)
        {
           _fitnessGymRepository = fitnessGymRepository;
        }
        public async Task Create(FitnessGym fitnessGym)
        {
            await _fitnessGymRepository.Create(fitnessGym);
        }
    }
}
