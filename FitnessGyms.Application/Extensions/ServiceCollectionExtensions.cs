
using AutoMapper;
using FitnessGyms.Application.ApplicationUser;
using FitnessGyms.Application.FitnessGym;
using FitnessGyms.Application.FitnessGym.Commands.CreateFitnessGym;
using FitnessGyms.Application.Mappings;
using FitnessGyms.Domain.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
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
            services.AddScoped<IUserContext, UserContext>();
            //services.AddAutoMapper(typeof(FitnessGymMappingProfile));
            services.AddMediatR(typeof(CreateFitnessGymCommand));

            services.AddScoped(provider => new MapperConfiguration(cfg =>
            {
                var scope = provider.CreateScope();
                var userContext = scope.ServiceProvider.GetRequiredService<IUserContext>();
                cfg.AddProfile(new FitnessGymMappingProfile(userContext));
            }).CreateMapper()
          );

            services.AddValidatorsFromAssemblyContaining<CreateFitnessGymCommandValidator>()
                    .AddFluentValidationAutoValidation()
                    .AddFluentValidationClientsideAdapters();


        }
    }
}
