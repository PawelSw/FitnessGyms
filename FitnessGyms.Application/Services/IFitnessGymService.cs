using FitnessGyms.Application.FitnessGym;
using FitnessGyms.Domain.Entities;

namespace FitnessGyms.Application.Services
{
    public interface IFitnessGymService
    {
        Task Create(FitnessGymDto fitnessGym);
        Task <IEnumerable<FitnessGymDto>> GetAll();
    }
}