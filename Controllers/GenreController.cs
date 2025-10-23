
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers;

public class GenreController : Controller
{
    private readonly ApplicationDbContext _db;
    public GenreController(ApplicationDbContext db)

    {
        _db = db;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Create()

    {
        return View();
    }
    [HttpPost]

    [ValidateAntiForgeryToken]
    public IActionResult Create(Genre genre)

    {

        _db.Genres.Add(genre);
        _db.SaveChanges();

        return RedirectToAction(nameof(Index));

    }
}