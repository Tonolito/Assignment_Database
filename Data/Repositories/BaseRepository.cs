using Data.Contexts;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;


namespace Data.Repositories;
/// <summary>
/// Repository to use CRUD to db
/// </summary>
/// <typeparam name="TEntity">Generic Entity</typeparam>
/// <param name="context"></param>
public abstract class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DataContext _context = context;
    protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
    private IDbContextTransaction _transaction = null!;




    #region TRANSACTION
    public virtual async Task BeginTransactionAsync()
    {
        if (_transaction == null)
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }
    }


    public virtual async Task CommitTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null!;
        }
    }

    public virtual async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null!;
        }
    }
    #endregion

    //Create
    /// <summary>
    /// Adds a entity
    /// </summary>
    /// <param name="entity">Generic Entity</param>
    /// <returns>Entity</returns>
    public virtual async Task<bool> CreateAsync(TEntity entity)
    {
        if (entity == null)
        {
            return false;
        }
        try
        {
            await _dbSet.AddAsync(entity);
            // TAGIT BORT SAVE
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"CreateAsync ({nameof(TEntity)}) Error: {ex}");
            return false;
        }
    }
    //Read
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
       return await _dbSet.ToListAsync();
        
    }

    public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbSet.AnyAsync(expression);


    }
    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        if (expression == null)
        {
            return null!;
        }

        return await _dbSet.FirstOrDefaultAsync(expression) ?? null!;
        
    }
    //Update
    public async Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity updatedEntity)
    {
        if (updatedEntity == null)
        {
            return null!;
        }
        try
        {
            var existingEntity = await _dbSet.FirstOrDefaultAsync(expression) ?? null!;
            if (existingEntity == null)
            {
                return null!;
            }
            _dbSet.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
            return existingEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"UpdateAsync ({nameof(TEntity)}) Error: {ex}");

            return null!;
        }
    }
    //Delete
    public virtual async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {
        if (expression == null)
        {
            return false;
        }
        try
        {
            var existingEntity = await _dbSet.FirstOrDefaultAsync(expression) ?? null!;
            if (existingEntity == null)
            {
                return false;
            }
            _dbSet.Remove(existingEntity);
            // TAGIT BORT SAVE
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"DeleteAsync ({nameof(TEntity)}) Error: {ex}");

            return false;
        }
    }

    //Save
    public virtual async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
    
}
