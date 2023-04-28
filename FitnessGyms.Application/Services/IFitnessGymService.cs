using FitnessGyms.Domain.Entities;

namespace FitnessGyms.Application.Services
{
    public interface IFitnessGymService
    {
        Task Create(FitnessGym fitnessGym);
    }
}