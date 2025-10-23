using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public static class DbSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Seed Genres
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Romance" },
                new Genre { Id = 2, Name = "Comedy" },
                new Genre { Id = 3, Name = "Horror" },
                new Genre { Id = 4, Name = "Sci-Fi" } // Exemple si besoin
            );

            // Seed Movies
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Name = "Inception", ImageUrl = "/images/inception.jpeg", GenreId = 4 },
                new Movie { Id = 2, Name = "Jurassic World", ImageUrl = "/images/jurassic.jpeg ", GenreId = 2 },
                new Movie { Id = 3, Name = "Bella", ImageUrl = "/images/91qMS2JSdhL._AC_UF1000,1000_QL80_.jpg", GenreId = 1 },
                new Movie { Id = 4, Name = "Pride and Prejudice", ImageUrl = "/images/pridePrejudice.jpeg", GenreId = 1 },
                new Movie { Id = 5, Name = "The Matrix", ImageUrl = "/images/matrix.jpeg", GenreId = 4 },
                new Movie { Id = 6, Name = "The Hangover", ImageUrl = "/images/hangover.jpeg", GenreId = 2 },
                new Movie { Id = 7, Name = "It", ImageUrl = "/images/it.jpeg", GenreId = 3 },
                new Movie { Id = 8, Name = "Titanic", ImageUrl = "/images/titanic.jpeg", GenreId = 1 },
                new Movie { Id = 9, Name = "Avengers: Endgame", ImageUrl = "/images/endgame.jpeg", GenreId = 4 },
                new Movie { Id = 10, Name = "Jumanji", ImageUrl = "/images/jumanji.jpeg", GenreId = 2 }
            );
        }
    }
}
