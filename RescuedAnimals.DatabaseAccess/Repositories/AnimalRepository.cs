﻿using RescuedAnimals.Model;
using RescuedAninmals.Common;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ApplicationResult> Create(Animal animal)
        {
            animal.DateModified = DateTime.UtcNow;
            animal.DateCreated = DateTime.UtcNow;
            await _context.AddAsync(animal);
            await _context.SaveChangesAsync();

            return new ApplicationResult();

        }

        public async Task<ApplicationResult> Update(Animal animal)
        {
            var item = await _context.Animals.FindAsync(animal.Id);

            item.Name = animal.Name;
            item.Type = animal.Type;
            item.Injury = animal.Injury;
            item.Status = animal.Status;
            item.Veterinarian = animal.Veterinarian;
            item.DateModified = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new ApplicationResult();

        }

        public async Task<ApplicationResult> Delete(Guid id)
        {
            var item = await _context.Animals.FindAsync(id);
            
            item.DateDeleted = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new ApplicationResult();
        }

        public async Task<ApplicationResult<Animal>> Get(Guid id)
        {
            var item = await Animals.Where(x => x.Id == id).ToListAsync();

            var result = new ApplicationResult<Animal>()
            {
                Result = item.FirstOrDefault()
            };
            if (!item.Any())
            {
                result.Errors.Add($"No items found for the id: {id}");
            }

            return result;
        }

        public async Task<ApplicationResult<CollectionResult<Animal>>> GetAll(AnimalFilter filter, PagingOptions pagingOptions)
        {
            var query = Animals;

            if (filter.VeterinarianId != null)
            {
                query = query.Where(x => x.VeterinarianId == filter.VeterinarianId);
            }

            query = query.Where(x => x.Name == filter.Name);           
            query = query.Where(x => x.Type == filter.Type);
            query = query.Where(x => x.Injury == filter.Injury);

            var items = await query.Skip(pagingOptions.Offset).Take(pagingOptions.Limit).ToListAsync();
            var total = await query.CountAsync();

            var result = new ApplicationResult<CollectionResult<Animal>>()
            {
                Result = new CollectionResult<Animal>
                {
                    Items = items,
                    Total = total
                }
            };

            if (total == 0)
            {
                result.Errors.Add("No items found for the specified criteria");
            }

            return result;

        }
    }
}
