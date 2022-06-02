namespace RescuedAnimals.Command.Veterinarians
{
    public class UpdateVeterinarianCommand
    {
        public UpdateVeterinarianCommand(string name)
        {
            Name = name;
        }


        public string Name { get; set; }
    }
}
