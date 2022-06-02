using RescuedAnimals.Command.Veterinarian;
using RescuedAninmals.Common;

namespace RescuedAnimals.Model.Veterinarians
{
    public interface IVeterinarianService
    {
        Task<ApplicationResult<Veterinarian>> CreateVeterinarian(CreateVeterinarianCommand command);

        Task<ApplicationResult<Veterinarian>> GetVeterinarian(Guid id);

        Task<ApplicationResult<CollectionResult<Veterinarian>>> GetAllVeterinarian(AnimalFilter filter, PagingOptions pagingOptions);

        Task<ApplicationResult> UpdateVeterinarian(Guid id, UpdateAnimalCommand updateCommand);

        Task<ApplicationResult> DeleteVeterinarian(Guid id);
    }
}
