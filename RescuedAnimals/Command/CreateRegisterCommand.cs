namespace RescuedAnimals.Model
{
    public class CreateRegisterCommand
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Injury { get; set; }

        public Veterinarian Veterinarian { get; set; }
    }
}