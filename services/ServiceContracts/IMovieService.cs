using WebApplication1.Models;
using System.Collections.Generic;
using WebApplication1.Helpers;
namespace WebApplication1.Services
{
    public interface IMovieService
    {
        Task<PaginatedList<Movie>> GetMoviesPaginatedAsync(int pageNumber, int pageSize);
        Task<Movie> GetMovieByIdAsync(int id);
        Task AddMovieAsync(Movie movie);
        Task UpdateMovieAsync(Movie movie);
        Task DeleteMovieAsync(Movie movie);
        IEnumerable<Movie> GetActionMovies();
        IEnumerable<Movie> GetMoviesOrdered();
    }
}
