using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ServiceRepository(DataContext context) : BaseRepository<ServiceEntity>(context), IServiceRepository
{
    public override async Task<IEnumerable<ServiceEntity>> GetAllAsync()
    {
        return await _context.Set<ServiceEntity>()
                    .Include(x => x.Unit)
                    .ToListAsync();
    }
}
