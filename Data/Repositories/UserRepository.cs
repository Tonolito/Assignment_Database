using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class UserRepository(DataContext context) : BaseRepository<UserEntity>(context), IUserRepository
{

    public override async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        return await _context.Set<UserEntity>()
            .Include(x => x.Role)
            .ToListAsync();
    }
}
