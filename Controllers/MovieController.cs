using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace AspCoreFirstApp2526.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }

       public IActionResult Index(int? page)
{
    int pageNumber = page ?? 1;
    int pageSize = 10;

    var movies = _db.Movies.OrderBy(m => m.Name); 
IPagedList<Movie> pagedMovies = new PagedList<Movie>(movies, pageNumber, pageSize);

            return View(pagedMovies);
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
