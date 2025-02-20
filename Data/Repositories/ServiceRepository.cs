using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class ServiceRepository(DataContext context) : BaseRepository<ServiceEntity>(context), IServiceRepository
{
    public override async Task<IEnumerable<ServiceEntity>> GetAllAsync()
    {
        return await _context.Set<ServiceEntity>()
                    .Include(x => x.Unit)
                    .ToListAsync();
    }
    public override async Task<ServiceEntity> GetAsync(Expression<Func<ServiceEntity, bool>> expression)
    {
        var result = await _context.Set<ServiceEntity>()
                            .Include(x => x.Unit)
                            .Where(expression)
                            .FirstOrDefaultAsync();

        if (result == null)
        {
            return null!;
        }
        return result;
    }
}

