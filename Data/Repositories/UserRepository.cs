using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repositories;

public class UserRepository(DataContext context) : BaseRepository<UserEntity>(context), IUserRepository
{

    public override async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        return await _context.Set<UserEntity>()
            .Include(x => x.Role)
            .ToListAsync();
    }
    public override async Task<UserEntity> GetAsync(Expression<Func<UserEntity, bool>> expression)
    {
        var result = await _context.Set<UserEntity>()
                       .Include(x => x.Role)
                       .Where(expression)
                       .FirstOrDefaultAsync();

        if (result == null)
        {
            return null!;
        }
        return result;
    }
}
