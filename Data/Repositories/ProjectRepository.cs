using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
    public override async Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        return await _context.Set<ProjectEntity>()
            .Include(p => p.Customer)
            .ThenInclude(c => c.CustomerContacts)
            .Include(p => p.Status)
            .Include(p => p.Service)
            .Include(p => p.User)
            .ToListAsync();
    }
}
