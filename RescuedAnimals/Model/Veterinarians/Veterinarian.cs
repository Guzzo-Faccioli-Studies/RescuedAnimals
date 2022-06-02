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

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime? DateDeleted { get; set; }

    }
}