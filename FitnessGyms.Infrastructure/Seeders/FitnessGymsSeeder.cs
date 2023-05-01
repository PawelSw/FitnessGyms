using FitnessGyms.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessGyms.Infrastructure.Seeders
{
    public class FitnessGymSeeder
    {
        private readonly FitnessGymsDbContext _dbContext;

        public FitnessGymSeeder(FitnessGymsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.FitnessGyms.Any())
                {
                    var roadToHealth = new Domain.Entities.FitnessGym()
                    {
                        Name = "Road to Health Gym",
                        Description = "Best place to keep fit.",
                        Opinions = "High quality service.",
                        ContactDetails = new()
                        {
                            City = "Rzeszów",
                            Street = "Rzeszowska 122",
                            PostalCode = "32-222",
                            PhoneNumber = "+48121212121"
                        }
                    };
                    roadToHealth.EncodeName();

                    _dbContext.FitnessGyms.Add(roadToHealth);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
