using RescuedAninmals.Common;
using System.Linq.Expressions;

namespace RescuedAnimals.Model

{
    public interface IAnimalRepository
    {
        Task<ApplicationResult> Create(Animal animal);

        Task<ApplicationResult<Animal>> Get(Guid id);

        Task<ApplicationResult<Animal>> GetAll(Expression<Func<Animal, bool>> filter, PagingOptions pagingOptions);

        Task<ApplicationResult> Update(Animal animal);

        Task<ApplicationResult> Delete(Guid id);


    }
}