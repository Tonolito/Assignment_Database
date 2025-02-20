using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class StatusTypeRepository(DataContext context) : BaseRepository<StatusTypeEntity>(context), IStatusTypeRepository
{
    public override async Task<StatusTypeEntity> GetAsync(Expression<Func<StatusTypeEntity, bool>> expression)
    {
        var result = await _context.Set<StatusTypeEntity>()
                       .Include(x => x.Projects)
                       .Where(expression)
                       .FirstOrDefaultAsync();


        if (result == null)
        {
            return null!;
        }

        return result;
    }
}
