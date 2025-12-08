using WebApplication1.Models;
using System.Collections.Generic;
using WebApplication1.Helpers;
namespace WebApplication1.Services
{
    public interface IMovieService
    {
   Task<PaginatedList<Movie>> GetMoviesPaginatedAsync(int pageNumber, int pageSize);

    Movie GetMovieById(int id);
    void UpdateMovie(Movie movie,IFormFile photo);
    void DeleteMovie(Movie movie);
    public IEnumerable<Genre> GetAllGenres();
    public void AddMovie(Movie movie, IFormFile photo);
    IEnumerable<Movie> GetActionMovies();
    IEnumerable<Movie> GetMoviesOrdered();
    }
}
