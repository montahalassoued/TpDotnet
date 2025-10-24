namespace WebApplication1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        // Relation 1 - Many avec MembershipType
        public int MembershipTypeId { get; set; }
        public MembershipType? MembershipType { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}

