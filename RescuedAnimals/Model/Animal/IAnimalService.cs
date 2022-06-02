using RescuedAninmals.Common;

namespace RescuedAnimals.Model
{
    public interface IAnimalService
    {
        Task<ApplicationResult<Animal>> CreateAnimal(CreateAnimalCommand command);

        Task<ApplicationResult<Animal>> GetAnimal(Guid id);

        Task<ApplicationResult<CollectionResult<Animal>>> GetAllAnimal(AnimalFilter filter, PagingOptions pagingOptions );

        Task<ApplicationResult> UpdateAnimal(Guid id, UpdateAnimalCommand updateCommand);

        Task<ApplicationResult> DeleteAnimal(Guid id);


    }
}
