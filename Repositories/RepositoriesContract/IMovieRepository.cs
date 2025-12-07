using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Repositories.RepositoriesContract;
public interface IMovieRepository
{
    Task<List<Movie>> GetAllMoviesAsync();
    Task<Movie> GetMovieByIdAsync(int id);
    Task AddMovieAsync(Movie movie);
    Task UpdateMovieAsync(Movie movie);
    Task DeleteMovieAsync(Movie movie);
}