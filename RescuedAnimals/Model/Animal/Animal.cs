using RescuedAnimals.Model.Veterinarians;

namespace RescuedAnimals.Model
{
    public class Animal
    {
        public Animal(Guid id, 
            string name, 
            string type, 
            string injury, 
            AnimalStatus status,
            Guid veterinarianId)
        {
            Id = id;
            Name = name;
            Type = type;
            Injury = injury;
            Status = status;
            VeterinarianId = veterinarianId;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Injury { get; set; }

        public AnimalStatus Status { get; set; }

        public Guid VeterinarianId { get; set; }

        public Veterinarian? Veterinarian { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime? DateDeleted { get; set; }
    }
}
