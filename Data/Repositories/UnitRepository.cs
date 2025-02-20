using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class UnitRepository(DataContext context) : BaseRepository<UnitEntity>(context), IUnitRepository
{
    public override async Task<UnitEntity> GetAsync(Expression<Func<UnitEntity, bool>> expression)
    {
        var result = await _context.Set<UnitEntity>()
               .Include(x => x.Services)
               .Where(expression)
               .FirstOrDefaultAsync();
              

        if (result == null)
        {
            return null!;
        }

        return result;
    }
}
