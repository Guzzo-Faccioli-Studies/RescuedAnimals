using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using RescuedAnimals.DatabaseAccess.Repositories;
using RescuedAnimals.Model;

namespace RescuedAnimals.DatabaseAccess
{
    public static class DatabaseAccessRegistry { 
        public static IServiceCollection AddAnimalDatabaseAccess(this IServiceCollection services, string connectionString, bool inMemory = false)
        {
            if (inMemory)
            {
                services.AddDbContext<AnimalsContext>(options =>
                    options.UseInMemoryDatabase("TestDatabase"));
            }
            else
            {
                services.AddDbContext<AnimalsContext>(options =>
                    options.UseSqlServer(connectionString));
            }

            services.AddTransient<IAnimalRepository, AnimalRepository>();

            return services;
}
    }
}
