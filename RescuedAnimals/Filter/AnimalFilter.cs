namespace RescuedAnimals.Model
{
    public class AnimalFilter
    {
        public AnimalFilter( string name, string type, string injury, Guid? veterinarianId)
        {
            Name = name;
            Type = type;
            Injury = injury;
            VeterinarianId = veterinarianId;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Injury { get; set; }

        public Guid? VeterinarianId { get; set; }

    }
}