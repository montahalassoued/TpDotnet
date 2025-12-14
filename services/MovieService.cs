using WebApplication1.Models;
using WebApplication1.Helpers;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Services


{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public MovieService(IWebHostEnvironment webHostEnvironment,ApplicationDbContext db)
        {
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }
        public async Task<PaginatedList<Movie>> GetMoviesPaginatedAsync(int pageNumber, int pageSize)
        {
            var query = _db.Movies.Include(m => m.Genre).OrderBy(m => m.Id).AsNoTracking();
            return await PaginatedList<Movie>.CreateAsync(query, pageNumber, pageSize); 
            }


        public Movie GetMovieById(int id)
        {
            return  _db.Movies.Include(m => m.Genre)
            .FirstOrDefault(m => m.Id == id);
        }
        public void UpdateMovie(Movie movie, IFormFile? imageFile = null)
        {
    var dbMovie = _db.Movies.FirstOrDefault(m => m.Id == movie.Id);
    if (dbMovie == null) return;

    if (imageFile != null && imageFile.Length > 0)
    {
        var fileName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            imageFile.CopyTo(stream);
        }

        dbMovie.ImageFile = fileName; 
    }

    dbMovie.Name = movie.Name;
    dbMovie.GenreId = movie.GenreId; 
    dbMovie.DateAjoutMovie = movie.DateAjoutMovie;

    _db.SaveChanges();
}


        public void DeleteMovie(Movie movie)
        {
            _db.Movies.Remove(movie);
            _db.SaveChanges();
        }

        public void AddMovie(Movie movie, IFormFile? imageFile = null)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                movie.ImageFile = fileName;
            }

            _db.Movies.Add(movie);
            _db.SaveChanges();
        }
        public IEnumerable<Genre> GetAllGenres()
        {
            return _db.Genres.ToList();
        }

        public IEnumerable<Movie> GetActionMovies()
        {
            return _db.Movies
                .Where(m => m.Genre.Name == "Action")
                .ToList();
        }

        public IEnumerable<Movie> GetMoviesOrdered()
        {
            return  _db.Movies
                .OrderBy(m => m.DateAjoutMovie)
                .ThenBy(m => m.Name)
                .ToList();
        }

        public int GetTotalMovies()
        {
            return _db.Movies.Count();
        }
        public async Task<List<Movie>> GetActionMoviesInStockAsync()
        {
            return await _db.Movies
            .Include(m => m.Genre)
            .Where(m => m.Genre.Name == "Action" && m.Stock > 0)
            .ToListAsync();
        }
        public async Task<List<Movie>> GetMoviesOrderedAsync()
        {
            return await _db.Movies
            .OrderBy(m => m.DateAjoutMovie)
            .ThenBy(m => m.Name)
            .ToListAsync();
            }
        public async Task<int> GetTotalMoviesCountAsync()
        {
            return await _db.Movies.CountAsync();
    }
    public async Task<List<Customer>> GetSubscribedCustomersWithDiscountAsync()
    {
        return await _db.Customers
        .Include(c => c.MembershipType)
        .Where(c => c.IsSubscribed && c.MembershipType.DiscountRate > 10)
        .ToListAsync();
        }
    public async Task<List<string>> GetMoviesWithGenresAsync()
    {
        var query = from m in _db.Movies
                join g in _db.Genres on m.GenreId equals g.Id
                select $"{m.Name} - {g.Name}";

    return await query.ToListAsync();
    }
    public async Task<List<Genre>> GetTop3GenresAsync()
    {
        return await _db.Genres
        .OrderByDescending(g => g.Movies.Count)
        .Take(3)
        .ToListAsync();
    }






    }

}
