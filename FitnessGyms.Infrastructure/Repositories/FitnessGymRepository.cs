﻿using FitnessGyms.Domain.Entities;
using FitnessGyms.Domain.Interfaces;
using FitnessGyms.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessGyms.Infrastructure.Repositories
{
    public class FitnessGymRepository : IFitnessGymRepository
    {
        private readonly FitnessGymsDbContext _dbContext;
        public FitnessGymRepository(FitnessGymsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Commit()
         => _dbContext.SaveChangesAsync();


        public async Task Create(FitnessGym fitnessGym)
        {
            _dbContext.Add(fitnessGym);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<FitnessGym>> GetAll()
         => await _dbContext.FitnessGyms.ToListAsync();

        public async Task<FitnessGym> GetByEncodedName(string encodedName)
         => await _dbContext.FitnessGyms.FirstAsync(cw => cw.EncodedName == encodedName);


        public Task<Domain.Entities.FitnessGym?> GetByName(string name)
         => _dbContext.FitnessGyms.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());
    }
}
