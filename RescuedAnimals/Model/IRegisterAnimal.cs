namespace RescuedAnimals.Model
{
    public interface IRegisterAnimal
    {
        Task<ApplicationResult<Animal>> CreateRegisterAnimal(CreateRegisterCommand command);

        Task<ApplicationResult<Animal>> GetRegister(Guid id);

        Task<ApplicationResult<CollectionResult<Animal>>> GetAllRegister(RegisterFilter filter);

        Task<ApplicationResult> UpdateRegister(Guid id, UpdateRegisterCommand updateCommand);

        Task<ApplicationResult> DeleteRegister(Guid id);


    }
}
