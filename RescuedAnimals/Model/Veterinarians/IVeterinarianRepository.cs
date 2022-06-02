using RescuedAnimals.Filter;
using RescuedAninmals.Common;

namespace RescuedAnimals.Model.Veterinarians
{
    public interface IVeterinarianRepository
    {
        Task<ApplicationResult> Create(Veterinarian veterinarian);

        Task<ApplicationResult<Veterinarian>> Get(Guid id);

        Task<ApplicationResult<CollectionResult<Veterinarian>>> GetAll(VeterinarianFilter filter, PagingOptions pagingOptions);

        Task<ApplicationResult> Update(Veterinarian veterinarian);

        Task<ApplicationResult> Delete(Guid id);

    }
}
