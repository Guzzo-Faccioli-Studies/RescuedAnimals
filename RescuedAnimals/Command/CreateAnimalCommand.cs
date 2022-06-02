namespace RescuedAnimals.Model
{
    public class CreateAnimalCommand
    {
        public CreateAnimalCommand(
            string name, 
            string type, 
            string injury, 
            AnimalStatus status,
            Guid veterinarianId)
        {
            Name = name;
            Type = type;
            Injury = injury;
            Status = status;
            VeterinarianId = veterinarianId;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Injury { get; set; }

        public AnimalStatus Status { get; set; }

        public Guid VeterinarianId { get; set; }
    }
}