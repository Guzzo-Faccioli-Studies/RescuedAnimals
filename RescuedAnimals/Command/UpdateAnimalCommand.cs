namespace RescuedAnimals.Model
{
    public class UpdateAnimalCommand
    {
        public UpdateAnimalCommand(string injury, Guid veterinarianId)
        {
            Injury = injury;
            VeterinarianId = veterinarianId;
        }

        public string Injury { get; set; }

        public Guid VeterinarianId { get; set; }
    }
}