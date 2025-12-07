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
            //Seed MembershipTypes
            modelBuilder.Entity<MembershipType>().HasData(
                new MembershipType { Id = 1, SignUpFee = 0, DurationInMonth = "1 Month", DiscountRate = 0 },
                new MembershipType { Id = 2, SignUpFee = 30, DurationInMonth = "3 Months", DiscountRate = 10 },
                new MembershipType { Id = 3, SignUpFee = 90, DurationInMonth = "6 Months", DiscountRate = 15 },
                new MembershipType { Id = 4, SignUpFee = 150, DurationInMonth = "1 Year", DiscountRate = 25 }
            );
            // Seed Customers
          modelBuilder.Entity<Customer>().HasData(
    new Customer { Id = 1, Name = "Alice Dupont", MembershipTypeId = 1, IsSubscribed = true },
    new Customer { Id = 2, Name = "Karim Ben Ali", MembershipTypeId = 2, IsSubscribed = false },
    new Customer { Id = 3, Name = "Sophie Martin", MembershipTypeId = 3, IsSubscribed = true },
    new Customer { Id = 4, Name = "Amine Trabelsi", MembershipTypeId = 4, IsSubscribed = false },
    new Customer { Id = 5, Name = "Lina Haddad", MembershipTypeId = 2, IsSubscribed = true }
);

        }
    }
}
