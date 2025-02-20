using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class RoleRepository(DataContext context) : BaseRepository<RoleEntity>(context), IRoleRepository
{
    public override async Task<RoleEntity> GetAsync(Expression<Func<RoleEntity, bool>> expression)
    {
        var result = await _context.Set<RoleEntity>()
            .Include(x => x.Users)
            .Where(expression)
            .FirstOrDefaultAsync();

        if (result == null)
        {
            return null!;
        }

        return result;
    }
}
