namespace RescuedAnimals.Model
{
    public class RegisterFilter
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Injury { get; set; }

        public Veterinarian Veterinarian { get; set; }
    }
}