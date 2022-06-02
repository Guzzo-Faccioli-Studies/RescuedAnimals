using Microsoft.EntityFrameworkCore;
using RescuedAnimals.Model;
using RescuedAnimals.Model.Veterinarians;

namespace RescuedAnimals.DatabaseAccess
{
    public class AnimalsContext : DbContext
    {   
        public AnimalsContext(DbContextOptions<AnimalsContext> options) : base(options)
        {
        }
        public DbSet<Animal> Animals { get; set; }

        public DbSet<Veterinarian> Veterinarians { get; set; }
    }
}
