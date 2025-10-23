namespace WebApplication1.Models
{
    public class MovietabViewModel
    {
        public List<Movie> Movies { get; set; }
        public Customer Customer { get; set; }

        // Constructeur
        public MovietabViewModel(List<Movie> movies, Customer customer)
        {
            Movies = movies;
            Customer = customer;
        }
    }
}

