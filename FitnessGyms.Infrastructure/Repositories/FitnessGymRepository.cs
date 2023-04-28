﻿using FitnessGyms.Domain.Entities;
using FitnessGyms.Domain.Interfaces;
using FitnessGyms.Infrastructure.Persistence;
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
        public async Task Create(FitnessGym fitnessGym)
        {
            _dbContext.Add(fitnessGym); 
            await _dbContext.SaveChangesAsync();
        }
    }
}