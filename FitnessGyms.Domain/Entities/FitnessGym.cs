namespace FitnessGyms.Domain.Entities
{
    public class FitnessGym
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public FitnessGymContactDetails ContactDetails { get; set; } = default!;

        //public string EncodedName { get; private set; } = default!;

        //public void EncodeName() => EncodedName = Name.ToLower().Replace(" ", "-");

       public string? About { get; set; }

    }
}
