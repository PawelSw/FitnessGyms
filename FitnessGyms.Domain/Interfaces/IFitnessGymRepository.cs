using FitnessGyms.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessGyms.Domain.Interfaces
{
    public interface IFitnessGymRepository
    {
        Task Create(FitnessGym fitnessGym);
        Task<Domain.Entities.FitnessGym?> GetByName(string name);
        Task <IEnumerable<FitnessGym>> GetAll();
        Task <FitnessGym> GetByEncodedName(string encodedName);
        Task Commit();
    }
}
