namespace WebApplication1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int MembershipTypeId { get; set; }
        public bool IsSubscribed { get; set; }
        public MembershipType? MembershipType { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}

