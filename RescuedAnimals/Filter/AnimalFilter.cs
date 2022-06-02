namespace RescuedAnimals.Model
{
    public class AnimalFilter
    {
        public AnimalFilter(Guid id, string name, string type, string injury, Guid veterinarianId)
        {
            Id = id;
            Name = name;
            Type = type;
            Injury = injury;
            VeterinarianId = veterinarianId;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Injury { get; set; }

        public Guid VeterinarianId { get; set; }

    }
}