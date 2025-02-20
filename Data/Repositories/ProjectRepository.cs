using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
    public override async Task<ProjectEntity> GetAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        var result =  await _context.Set<ProjectEntity>()
        .Include(p => p.Customer)
        .ThenInclude(c => c.CustomerContacts)
        .Include(p => p.Status)
        .Include(p => p.Service)
        .Include(p => p.User)
        .Where(expression) 
        .FirstOrDefaultAsync();

        if (result == null)
        {
            return null!;
        }

        return result;

    }

}
