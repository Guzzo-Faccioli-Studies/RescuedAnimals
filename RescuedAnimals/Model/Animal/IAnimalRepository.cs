using RescuedAninmals.Common;

namespace RescuedAnimals.Model

{
    public interface IAnimalRepository
    {
        Task<ApplicationResult> Create(Animal animal);

        Task<ApplicationResult<Animal>> Get(Guid id);

        Task<ApplicationResult<CollectionResult<Animal>>> GetAll(AnimalFilter filter, PagingOptions pagingOptions);

        Task<ApplicationResult> Update(Animal animal);

        Task<ApplicationResult> Delete(Guid id);


    }
}