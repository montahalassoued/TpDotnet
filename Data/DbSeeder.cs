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
    new Movie { 
        Id = 1, 
        Name = "Inception", 
        ImageFile = "inception.jpeg", 
        GenreId = 4, 
        Stock = 5,
        DateAjoutMovie = new DateTime(2025, 12, 8, 0, 0, 0, DateTimeKind.Utc)
    },
    new Movie { 
        Id = 2, 
        Name = "Jurassic World", 
        ImageFile = "jurassic.jpeg", 
        GenreId = 2, 
        Stock = 3,
        DateAjoutMovie = new DateTime(2025, 12, 8, 0, 0, 0, DateTimeKind.Utc)
    },
    new Movie { 
        Id = 3, 
        Name = "Bella", 
        ImageFile = "91qMS2JSdhL._AC_UF1000,1000_QL80_.jpg", 
        GenreId = 1, 
        Stock = 0,
        DateAjoutMovie = new DateTime(2025, 12, 8, 0, 0, 0, DateTimeKind.Utc)
    },
    new Movie { 
        Id = 4, 
        Name = "Pride and Prejudice", 
        ImageFile = "pridePrejudice.jpeg", 
        GenreId = 1, 
        Stock = 2,
        DateAjoutMovie = new DateTime(2025, 12, 8, 0, 0, 0, DateTimeKind.Utc)
    },
    new Movie { 
        Id = 5, 
        Name = "The Matrix", 
        ImageFile = "matrix.jpeg", 
        GenreId = 4, 
        Stock = 6,
        DateAjoutMovie = new DateTime(2025, 12, 8, 0, 0, 0, DateTimeKind.Utc)
    },
    new Movie { 
        Id = 6, 
        Name = "The Hangover", 
        ImageFile = "hangover.jpeg", 
        GenreId = 2, 
        Stock = 4,
        DateAjoutMovie = new DateTime(2025, 12, 8, 0, 0, 0, DateTimeKind.Utc)
    },
    new Movie { 
        Id = 7, 
        Name = "It", 
        ImageFile = "it.jpeg", 
        GenreId = 3, 
        Stock = 1,
        DateAjoutMovie = new DateTime(2025, 12, 8, 0, 0, 0, DateTimeKind.Utc)
    },
    new Movie { 
        Id = 8, 
        Name = "Titanic", 
        ImageFile = "titanic.jpeg", 
        GenreId = 1, 
        Stock = 0,
        DateAjoutMovie = new DateTime(2025, 12, 8, 0, 0, 0, DateTimeKind.Utc)
    },
    new Movie { 
        Id = 9, 
        Name = "Avengers: Endgame", 
        ImageFile = "endgame.jpeg", 
        GenreId = 4, 
        Stock = 7,
        DateAjoutMovie = new DateTime(2025, 12, 8, 0, 0, 0, DateTimeKind.Utc)
    },
    new Movie { 
        Id = 10, 
        Name = "Jumanji", 
        ImageFile = "jumanji.jpeg", 
        GenreId = 2, 
        Stock = 3,
        DateAjoutMovie = new DateTime(2025, 12, 8, 0, 0, 0, DateTimeKind.Utc)
    }
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
// --- Seed Produits (nouveauté) ---
 modelBuilder.Entity<Produit>().HasData(
                new Produit { Id = 1, Nom = "Ordinateur Portable", Description = "Dell XPS 15, 16GB RAM, 512GB SSD", Prix = 1299.99m, Stock = 10, ImageUrl = "/images/laptop.jpg", DateAjout = new DateTime(2025, 12, 26, 10, 0, 0, DateTimeKind.Utc) },
                new Produit { Id = 2, Nom = "Souris Sans Fil", Description = "Logitech MX Master 3", Prix = 99.99m, Stock = 50, ImageUrl = "/images/mouse.jpg", DateAjout = new DateTime(2025, 12, 26, 10, 5, 0, DateTimeKind.Utc) },
                new Produit { Id = 3, Nom = "Clavier Mécanique", Description = "Corsair K95 RGB", Prix = 199.99m, Stock = 25, ImageUrl = "/images/keyboard.jpg", DateAjout = new DateTime(2025, 12, 26, 10, 10, 0, DateTimeKind.Utc) },
                new Produit { Id = 4, Nom = "Écouteurs Bluetooth", Description = "Sony WH-1000XM4", Prix = 349.99m, Stock = 30, ImageUrl = "/images/headphones.jpg", DateAjout = new DateTime(2025, 12, 26, 10, 15, 0, DateTimeKind.Utc) }
            );
     string user1Id = "user-1";
            string user2Id = "user-2";

            modelBuilder.Entity<PanierParUser>().HasData(
                new PanierParUser
                {
                    Id = 1,
                    UserID = user1Id,
                    ProduitId = 1, // Ordinateur Portable
                    Quantite = 1,
                    DateAjout = new DateTime(2025, 12, 26, 11, 0, 0, DateTimeKind.Utc)
                },
                new PanierParUser
                {
                    Id = 2,
                    UserID = user1Id,
                    ProduitId = 2, // Souris Sans Fil
                    Quantite = 2,
                    DateAjout = new DateTime(2025, 12, 26, 11, 5, 0, DateTimeKind.Utc)
                },
                new PanierParUser
                {
                    Id = 3,
                    UserID = user2Id,
                    ProduitId = 3, // Clavier Mécanique
                    Quantite = 1,
                    DateAjout = new DateTime(2025, 12, 26, 11, 10, 0, DateTimeKind.Utc)
                }
            );

        }
    }
}
