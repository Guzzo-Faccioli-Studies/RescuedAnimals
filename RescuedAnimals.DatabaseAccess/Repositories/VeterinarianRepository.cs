using Microsoft.EntityFrameworkCore;
using RescuedAnimals.Filter;
using RescuedAnimals.Model;
using RescuedAnimals.Model.Veterinarians;
using RescuedAninmals.Common;

namespace RescuedAnimals.DatabaseAccess.Repositories
{
    public class VeterinarianRepository : IVeterinarianRepository
    {
        private readonly AnimalsContext _context;

        private IQueryable<Veterinarian> Veterinarians => _context.Veterinarians.AsQueryable();

        public VeterinarianRepository(AnimalsContext context)
        {
            _context = context;
        }

        public async Task<ApplicationResult> Create(Veterinarian veterinarian)
        {
            veterinarian.DateModified = DateTime.UtcNow;
            veterinarian.DateCreated = DateTime.UtcNow;
            await _context.AddAsync(veterinarian);
            await _context.SaveChangesAsync();

            return new ApplicationResult();
        }
        public async Task<ApplicationResult> Update(Veterinarian veterinarian)
        {
            var item = await _context.Veterinarians.FindAsync(veterinarian.Id);

            item.Name = veterinarian.Name;
            item.DateModified = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new ApplicationResult();

        }

        public async Task<ApplicationResult> Delete(Guid id)
        {
            var item = await _context.Veterinarians.FindAsync(id);

            item.DateDeleted = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new ApplicationResult();
        }

        public async Task<ApplicationResult<Veterinarian>> Get(Guid id)
        {
            var item = await Veterinarians.Where(x => x.Id == id).ToListAsync();

            var result = new ApplicationResult<Veterinarian>()
            {
                Result = item.FirstOrDefault()
            };
            if (!item.Any())
            {
                result.Errors.Add(($"No items found for the id: {id}");
            }

            return result;
        }

        public async Task<ApplicationResult<CollectionResult<Veterinarian>>> GetAll(VeterinarianFilter filter, PagingOptions pagingOptions)
        {
            var query = Veterinarians;

            query = query.Where(x => x.Name == filter.Name);

            var items = await query.Skip(pagingOptions.Offset).Take(pagingOptions.Limit).ToListAsync();
            var total = await query.CountAsync();

            var result = new ApplicationResult<CollectionResult<Veterinarian>>
            {
                Result = new CollectionResult<Veterinarian>
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
