using RescuedAninmals.Common;

namespace RescuedAnimals.Model
{
    internal class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService (IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<ApplicationResult<Animal>> CreateAnimal(CreateAnimalCommand command)
        {
            var entity = new Animal(Guid.NewGuid(),
                command.Name,
                command.Type,
                command.Injury,
                command.Status,
                command.VeterinarianId
                );

            var creationResult = await _animalRepository.Create(entity);

            var result = new ApplicationResult<Animal>
            {
                Result = creationResult.IsSuccess ? entity : null,
                Errors = creationResult.Errors
            };

            return result;
        }

        public async Task<ApplicationResult> UpdateAnimal(Guid id, UpdateAnimalCommand updateCommand)
        {
            var searchResult = await _animalRepository.Get(id);

            var entity = searchResult.Result;

            if (entity == null)
            {
                return new ApplicationResult
                {
                    Errors = new List<string> { "Chat not found!" }
                };
            }

            entity.Id = id;
            entity.Injury = updateCommand.Injury;
            entity.VeterinarianId = updateCommand.VeterinarianId;

            var updateResult = await _animalRepository.Update(entity);

            var result = new ApplicationResult<Animal>
            {
                Result = updateResult.IsSuccess ? entity : null,
                Errors = updateResult.Errors
            };

            return result;
        }

        public async Task<ApplicationResult> DeleteAnimal(Guid Id)
        {
            var deleteResult = await _animalRepository.Delete(Id);

            var result = new ApplicationResult
            {
                Errors = deleteResult.Errors
            };

            return result;
        }

        public Task<ApplicationResult<CollectionResult<Animal>>> GetAllAnimal(AnimalFilter filter, PagingOptions pagingOptions)
        {
            return _animalRepository.GetAll(filter, pagingOptions);
        }

        public Task<ApplicationResult<Animal>> GetAnimal(Guid id)
        {
            return _animalRepository.Get(id);
        }
    }
}
