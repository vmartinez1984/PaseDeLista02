﻿using Microsoft.Extensions.DependencyInjection;
using RollCall.Core.Interfaces;
using RollCall.Repositories.Contexts;
using RollCall.Repositories.Repositories;

namespace RollCall.Repositories.Extensor
{
    public static class RepositorioExtensor
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();

            services.AddScoped<IPersonRepository, PersonRepository>();  

            services.AddScoped<IRepository, Repository>();
        }
    }
}