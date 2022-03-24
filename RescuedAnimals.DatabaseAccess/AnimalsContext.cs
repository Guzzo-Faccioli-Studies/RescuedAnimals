using Microsoft.EntityFrameworkCore;
using RescuedAnimals.Model;

namespace RescuedAnimals.DatabaseAccess
{
    public class AnimalsContext : DbContext
    {   public AnimalsContext(DbContextOptions<AnimalsContext> options) : base(options)
        {
        }
        public DbSet<Animal> RescuedAnimals { get; set; }
    }
}
