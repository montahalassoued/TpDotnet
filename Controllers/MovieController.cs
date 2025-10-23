using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Helpers; 
using Microsoft.EntityFrameworkCore;

namespace AspCoreFirstApp2526.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }

public async Task<IActionResult> Index(int? page)
    {
        int pageSize = 5; // Nombre de movies par page
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

        public IActionResult Details()
        {
            var movies = _db.Movies.ToList();
            Customer c = new Customer(1, "mohamedAli");
            MovietabViewModel movietabViewModel = new MovietabViewModel(movies, c);
            return View(movietabViewModel);
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
    }
}
