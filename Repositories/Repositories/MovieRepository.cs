using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Repositories.RepositoriesContract;

namespace WebApplication1.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _db;

        public MovieRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _db.Movies.Include(m => m.Genre).ToListAsync();
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

        public async Task DeleteMovieAsync(Movie movie)
        {
            _db.Movies.Remove(movie);
            await _db.SaveChangesAsync();
        }
    }
}
