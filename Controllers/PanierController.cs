using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class PanierController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public PanierController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        // Question 3: Action pour récupérer les produits d'un utilisateur
        public IActionResult PanierParUser()
        {
            var currentuser = _userManager.GetUserId(User);
            
            var paniers = _db.Paniers
                .Include(p => p.Produit)
                .Where(c => c.UserID == currentuser)
                .ToList();
            
            return View(paniers);
        }

        // Action helper pour initialiser quelques produits (pour tester)


        // Action helper pour ajouter des produits au panier de l'utilisateur actuel
        public IActionResult SeedPanier()
        {
            var currentuser = _userManager.GetUserId(User);
            
            if (currentuser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Vérifier si l'utilisateur a déjà des produits dans son panier
            if (!_db.Paniers.Any(p => p.UserID == currentuser))
            {
                var produits = _db.Produits.Take(2).ToList();
                
                if (produits.Any())
                {
                    foreach (var produit in produits)
                    {
                        _db.Paniers.Add(new PanierParUser
                        {
                            Id = 0,
                            UserID = currentuser,
                            ProduitId = produit.Id,
                            Quantite = 1
                        });
                    }
                    
                    _db.SaveChanges();
                }
            }

            return RedirectToAction("PanierParUser");
        }
    }
}
