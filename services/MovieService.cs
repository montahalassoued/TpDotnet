using WebApplication1.Models;
using WebApplication1.Helpers;
using WebApplication1.Services;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Services


{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _db;

        public MovieService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<PaginatedList<Movie>> GetMoviesPaginatedAsync(int pageNumber, int pageSize)
        {
            var query = _db.Movies
            .Include(m => m.Genre)
            .OrderBy(m => m.Id)
            .AsNoTracking();
            return await PaginatedList<Movie>.CreateAsync(query, pageNumber, pageSize);
        }
        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _db.Movies.Include(m => m.Genre).FirstOrDefaultAsync(m => m.Id == id);
        }
        public async Task AddMovieAsync(Movie movie)
        {
            _db.Movies.Add(movie);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateMovieAsync(Movie movie)
        {
            _db.Movies.Update(movie);
            await _db.SaveChangesAsync();
        }
        


        public IEnumerable<Movie> GetActionMovies()
        {
            return _db.Movies
                .Where(m => m.Genre.Name == "Action")
                .ToList();
        }

        public IEnumerable<Movie> GetMoviesOrdered()
        {
            return _db.Movies
                .OrderBy(m => m.DateAjoutMovie)
                .ThenBy(m => m.Name)
                .ToList();
        }

        public int GetTotalMovies()
        {
            return _db.Movies.Count();
        }
    }
}
