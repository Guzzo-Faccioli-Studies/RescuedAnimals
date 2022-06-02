namespace RescuedAnimals.Model.Veterinarians
{
    public class Veterinarian
    {
        public Veterinarian(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

    }
}