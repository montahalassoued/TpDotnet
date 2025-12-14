using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Repositories.GenericRepo;
public class GenericRepository<T> : IGenericRepository<T> where T : class {
private readonly ApplicationDbContext _db;

    public GenericRepository(ApplicationDbContext db)
    {
        _db = db;
    }
     public IQueryable<T> GetAll()
    {
        return _db.Set<T>();
    }
    public async Task<List<T>> GetAllAsync()
    {
        return await _db.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _db.Set<T>().FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await _db.Set<T>().AddAsync(entity);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _db.Set<T>().Update(entity);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _db.Set<T>().Remove(entity);
        await _db.SaveChangesAsync();
    }
}