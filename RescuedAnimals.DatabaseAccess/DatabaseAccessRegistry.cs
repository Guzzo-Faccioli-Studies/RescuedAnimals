using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;


namespace RescuedAnimals.DatabaseAccess
{
    public static class DatabaseAccessRegistry { 
        public static IServiceCollection AddCatalogDatabaseAccess(this IServiceCollection services, string connectionString, bool inMemory = false)
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
