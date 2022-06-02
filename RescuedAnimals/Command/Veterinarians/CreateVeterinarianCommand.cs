namespace RescuedAnimals.Command.Veterinarian
{
    public class CreateVeterinarianCommand
    {
        public CreateVeterinarianCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
