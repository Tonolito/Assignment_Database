using System.Linq.Expressions;

namespace Data.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    // CREATE
     Task<TEntity> CreateAsync(TEntity entity);

    // READ
    Task<IEnumerable<TEntity>> GetAllAsync(TEntity entity);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
    // UPDATE
    Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity updatedEntity);
    //DELETE
    Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression);


}
