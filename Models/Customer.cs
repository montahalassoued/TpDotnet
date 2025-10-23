namespace WebApplication1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        // Constructeur
        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

