using System;
using RescuedAnimals.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RescuedAnimals.DatabaseAccess.Repositories
{
    internal class AnimalRepository : IAnimalRepository
    {
        private readonly AnimalsContext _context;

        private IQueryable<Animal> Animals => _context.Animals.AsQueryable();

        public AnimalRepository(AnimalsContext context)
        {
            _context = context;
        }
    }
}
