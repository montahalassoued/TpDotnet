using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Helpers; 
using Microsoft.EntityFrameworkCore;
using WebApplication1.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace WebApplication1.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MovieController(IMovieService movieService , IWebHostEnvironment webHostEnvironment)
        {
            _movieService = movieService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index(int? page)
       {
        int pageSize = 5;
        int pageNumber = page ?? 1;

        var movies = await _movieService.GetMoviesPaginatedAsync(pageNumber, pageSize);
        return View(movies);
        }
        public IActionResult ByRelease(int year, int month)
        {
            return Content($"Movies released in {month}/{year}");
        }
        //Movie/id
       public IActionResult Details(int id){
       // Call the service to get the movie
       var movie = _movieService.GetMovieById(id);
       if (movie == null)
            return NotFound();
       return View(movie);
       }
         public IActionResult Edit(int id)
    {
    var movie = _movieService.GetMovieById(id);
    if (movie == null) return NotFound();

    ViewData["Genres"] = new SelectList(_movieService.GetAllGenres(), "Id", "Name", movie.GenreId);
    return View(movie);
    }
    // POST: /Movie/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
   public IActionResult Edit(int id, Movie movie, IFormFile? imageFile)
        {
            if (id != movie.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                _movieService.UpdateMovie(movie, imageFile);
                return RedirectToAction("Index"); // ou vers la page de détails
            }

            // Si le model est invalide, revenir à la vue avec le model
            return View(movie);
        }

// GET: /Movie/Delete/5
       public IActionResult Delete(int id)
    {
       var movie = _movieService.GetMovieById(id);
       if (movie == null) return NotFound();
       return View(movie);
       }

// POST: /Movie/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public IActionResult DeleteConfirmed(int id)
{
    var movie = _movieService.GetMovieById(id);
    if (movie == null) return NotFound();

    _movieService.DeleteMovie(movie);
    return RedirectToAction(nameof(Index));
}
[HttpGet]
public IActionResult Create()
{
    // Fournir la liste des genres pour le dropdown
    ViewData["Genres"] = new SelectList(_movieService.GetAllGenres(), "Id", "Name");

    // Retourner un MovieVM vide pour le formulaire
    return View(new MovieVM());
}

 [HttpPost]
 [ValidateAntiForgeryToken]
 public IActionResult Create(MovieVM model)
 {
    if (model.photo == null)
    return Content("File not uploaded");
    if (model.movie.DateAjoutMovie.HasValue)
{
    model.movie.DateAjoutMovie = DateTime.SpecifyKind(model.movie.DateAjoutMovie.Value, DateTimeKind.Utc);
}

    if (ModelState.IsValid)
    {
        var movie = new Movie
        {
            Name = model.movie.Name,
            DateAjoutMovie = model.movie.DateAjoutMovie,
            GenreId = model.movie.GenreId
        };

        _movieService.AddMovie(model.movie, model.photo);
        return RedirectToAction(nameof(Index));
    }
    ViewData["Genres"] = new SelectList(_movieService.GetAllGenres(), "Id", "Name", model.movie.GenreId);
    return View(model);
 }
    }
}
