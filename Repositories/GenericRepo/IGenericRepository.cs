using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Repositories.GenericRepo
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll(); 
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
