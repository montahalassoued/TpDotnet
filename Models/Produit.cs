using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Produit
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nom { get; set; }

        public string? Description { get; set; }

        [Required]
        public decimal Prix { get; set; }

        public int Stock { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime DateAjout { get; set; } = DateTime.UtcNow;

        // Navigation property
        public List<PanierParUser>? Paniers { get; set; }
    }
}
