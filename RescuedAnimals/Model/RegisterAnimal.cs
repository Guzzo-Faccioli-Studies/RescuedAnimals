using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RescuedAnimals.Model
{
    internal class RegisterAnimal : IRegisterAnimal
    {
        private readonly IAnimalRepository _animalRepository;

        public RegisterAnimal (IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<ApplicationResult<Animal>> CreateRegisterAnimal(CreateRegisterCommand command)
        {
            var entity = new Animal
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Injury = command.Injury,
                Type = command.Type,
                Veterinarian = command.Veterinarian,
                Status = AnimalStatus.Consulting
            };

            var creationResult = await _animalRepository.Create(entity);

            var result = new ApplicationResult<Animal>
            {
                Result = creationResult.IsSuccess ? entity : null,
                Errors = creationResult.Errors
            };

            return result;
        }

        public Task<ApplicationResult<CollectionResult<Animal>>> GetAllRegister(RegisterFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationResult<Animal>> GetRegister(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationResult> UpdateRegister(Guid Id, UpdateRegisterCommand updateCommand)
        {
            throw new NotImplementedException();
        }
    }
}
