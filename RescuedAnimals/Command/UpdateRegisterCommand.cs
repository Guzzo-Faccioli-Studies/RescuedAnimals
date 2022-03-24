namespace RescuedAnimals.Model
{
    public class UpdateRegisterCommand
    {
        public UpdateRegisterCommand(string injury, Veterinarian veterinarian)
        {
            Injury = injury;
            Veterinarian = veterinarian;
        }

        public string Injury { get; set; }

        public Veterinarian Veterinarian { get; set; }
    }
}