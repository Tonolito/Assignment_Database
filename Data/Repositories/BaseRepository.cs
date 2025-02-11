using Data.Contexts;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;
/// <summary>
/// Repository to use CRUD to db
/// </summary>
/// <typeparam name="TEntity">Generic Entity</typeparam>
/// <param name="context"></param>
public class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DataContext _context = context;
    protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    //           https://youtu.be/qKxl0f6ZwqA?t=309
    //Create
    /// <summary>
    /// Creates an Entity and saves it to the db
    /// </summary>
    /// <param name="entity">Generic Entity</param>
    /// <returns>Entity</returns>
    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"CreateAsync Error: {ex}");
            return null!;
        }
    }
    //Read
    public Task<IEnumerable<TEntity>> GetAllAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
    public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        throw new NotImplementedException();
    }
    public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        throw new NotImplementedException();
    }
    //Update
    public Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity updatedEntity)
    {
        throw new NotImplementedException();
    }
    //Delete
    public Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {       
        throw new NotImplementedException();
    }
    
}
