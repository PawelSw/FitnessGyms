using FitnessGyms.Domain.Interfaces;
using FitnessGyms.Infrastructure.Persistence;
using FitnessGyms.Infrastructure.Repositories;
using FitnessGyms.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessGyms.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FitnessGymsDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("FitnessGymsDatabaseConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<FitnessGymsDbContext>();
            services.AddScoped<FitnessGymSeeder>();
            services.AddScoped<IFitnessGymRepository, FitnessGymRepository>();

        }
    }
}
