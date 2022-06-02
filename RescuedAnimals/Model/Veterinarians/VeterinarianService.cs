using RescuedAnimals.Command.Veterinarian;
using RescuedAnimals.Command.Veterinarians;
using RescuedAnimals.Filter;
using RescuedAninmals.Common;

namespace RescuedAnimals.Model.Veterinarians
{
    public class VeterinarianService : IVeterinarianService
    {
        private readonly IVeterinarianRepository _veterinarianRepository;

        public VeterinarianService(IVeterinarianRepository veterinarianRepository)
        {
            _veterinarianRepository = veterinarianRepository;
        }

        public async Task<ApplicationResult<Veterinarian>> CreateVeterinarian(CreateVeterinarianCommand command)
        {
            var entity = new Veterinarian(Guid.NewGuid(), command.Name);

            var creationResult = await _veterinarianRepository.Create(entity);

            var result = new ApplicationResult<Veterinarian>
            {
                Result = creationResult.IsSuccess ? entity : null,
                Errors = creationResult.Errors
            };

            return result;
        }

        public async Task<ApplicationResult> UpdateVeterinarian(Guid id, UpdateVeterinarianCommand command)
        {
            var searchResult = await _veterinarianRepository.Get(id);

            var entity = searchResult.Result;

            if (entity == null)
            {
                return new ApplicationResult
                {
                    Errors = new List<string> { "Veterinarian not found!" }
                };
            }

            entity.Id = id;
            entity.Name = command.Name;

            var updateResult = await _veterinarianRepository.Update(entity);

            var result = new ApplicationResult<Veterinarian>
            {
                Result = updateResult.IsSuccess ? entity : null,
                Errors = updateResult.Errors
            };

            return result;
        }

        public async Task<ApplicationResult> DeleteVeterinarian(Guid id)
        {
            var deleteResult = await _veterinarianRepository.Delete(id);

            var result = new ApplicationResult
            {
                Errors = deleteResult.Errors
            };

            return result;
        }

        public Task<ApplicationResult<CollectionResult<Veterinarian>>> GetAllVeterinarian(VeterinarianFilter filter, PagingOptions pagingOptions)
        {
            return _veterinarianRepository.GetAll(filter, pagingOptions);
        }

        public Task<ApplicationResult<Veterinarian>> GetVeterinarian(Guid id)
        {
            return _veterinarianRepository.Get(id);
        }

       
    }
}
