namespace WebApplication1.Models

{
    public class Movie
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }
        public List<Customer>? Customers { get; set; }
        public string? ImageFile { get; set; }
        public DateTime? DateAjoutMovie { get; set; }
    }
}