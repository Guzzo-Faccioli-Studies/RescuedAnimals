namespace RescuedAnimals.Filter
{
    public class VeterinarianFilter
    {
        public VeterinarianFilter(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
