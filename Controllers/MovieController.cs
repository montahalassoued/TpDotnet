using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Helpers; 
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication1.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MovieController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

public async Task<IActionResult> Index(int? page)
    {
        int pageSize = 5; 
        int pageNumber = page ?? 1;

        var moviesQuery = _db.Movies
            .Include(m => m.Genre)
            .OrderBy(m => m.Id)
            .AsNoTracking();

        var movies = await PaginatedList<Movie>.CreateAsync(moviesQuery, pageNumber, pageSize);

        return View(movies);
    }
        public IActionResult ByRelease(int year, int month)
        {
            return Content($"Movies released in {month}/{year}");
        }

        public IActionResult Details(int id)
{
    var movie = _db.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == id);
    if (movie == null)
        return NotFound();

    return View(movie);
}


        // GET: Edit
        public IActionResult Edit(int id)
        {
            var movie = _db.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null) return NotFound();

            ViewData["Genres"] = new SelectList(_db.Genres, "Id", "Name", movie.GenreId);
            return View(movie);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _db.Movies.Update(movie);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Genres"] = new SelectList(_db.Genres, "Id", "Name", movie.GenreId);
            return View(movie);
        }

        public IActionResult Delete(int id)
        {
            var movie = _db.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _db.Movies.Find(id);
            if (movie == null) return NotFound();

            _db.Movies.Remove(movie);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        // GET: Movie/Create
public IActionResult Create()
{
    return View();
}

        [HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(MovieVM model, IFormFile photo)
{
if (photo == null)
return Content("File not uploaded");
try
{
//Combine trois chaînes dans un seul path
var path = Path.Combine(_webHostEnvironment.WebRootPath, "images",
photo.FileName);
//fournit un stream pour la lecture et ecriture dans un fichier
using (FileStream stream = new FileStream(path, FileMode.Create))
{
photo.CopyTo(stream);
stream.Close();
}
model.movie.ImageFile = photo.FileName;
//Mapping entre Model et ViewModel
var movie = new Movie
{
Name = model.movie.Name,
DateAjoutMovie = model.movie.DateAjoutMovie,
ImageFile = photo.FileName,
};
_db.Add(movie);
_db.SaveChanges();

return RedirectToAction(nameof(Index));
}
catch (Exception)
{
throw;
}
}
public IActionResult TestAudit()
{
    // --- 1. Ajouter un film ---
    var movie = new Movie
    {
        Name = "Test Movie",
        DateAjoutMovie = DateTime.UtcNow,
        ImageFile = "test.jpg",
        GenreId = 1
    };
    _db.Movies.Add(movie);
    _db.SaveChanges(); // <-- AuditLog déclenché

    // --- 2. Modifier le film ---
    movie.Name = "Test Movie Updated";
    _db.Movies.Update(movie);
    _db.SaveChanges(); // <-- AuditLog enregistré

    // --- 3. Supprimer le film ---
    _db.Movies.Remove(movie);
    _db.SaveChanges(); // <-- AuditLog enregistré

    // --- 4. Lire les logs ---
    var logs = _db.AuditLogs
        .OrderByDescending(a => a.Date)
        .Take(10)
        .ToList();

    return View("AuditLogs", logs); // renvoie à une vue AuditLogs
}

    }
}
