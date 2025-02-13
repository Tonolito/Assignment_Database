﻿using Data.Contexts;
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
public abstract class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class
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
        if (entity == null)
        {
            return null!;
        }
        try
        {
            await _dbSet.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"CreateAsync ({nameof(TEntity)}) Error: {ex}");
            return null!;
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
            await _context.SaveChangesAsync();
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
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"DeleteAsync ({nameof(TEntity)}) Error: {ex}");

            return false;
        }
    }
    
}
