using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class PanierParUser
    {
        public int  Id { get; set; }

        [Required]
        public string? UserID { get; set; }

        [Required]
        public int  ProduitId { get; set; }

        public int Quantite { get; set; } = 1;

        public DateTime DateAjout { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public ApplicationUser? User { get; set; }
        public Produit? Produit { get; set; }
    }
}
