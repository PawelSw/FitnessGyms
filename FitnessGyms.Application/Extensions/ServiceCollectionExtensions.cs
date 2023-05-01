



using FitnessGyms.Application.FitnessGym;
using FitnessGyms.Application.Mappings;
using FitnessGyms.Application.Services;
using FitnessGyms.Domain.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessGyms.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
           services.AddScoped<IFitnessGymService, FitnessGymService>();
            services.AddAutoMapper(typeof(FitnessGymMappingProfile));

            services.AddValidatorsFromAssemblyContaining<FitnessGymDtoValidator>()
                    .AddFluentValidationAutoValidation()
                    .AddFluentValidationClientsideAdapters();


        }
    }
}
