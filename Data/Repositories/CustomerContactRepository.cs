using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class CustomerContactRepository(DataContext context) : BaseRepository<CustomerContactEntity>(context), ICustomerContactRepository
{
    
    public override async Task<IEnumerable<CustomerContactEntity>> GetAllAsync()
    {
        return await _context.Set<CustomerContactEntity>()
            .Include(x => x.Customer)
            .ToListAsync();
    }
    public override async Task<CustomerContactEntity> GetAsync(Expression<Func<CustomerContactEntity, bool>> expression)
    {
        var result = await _context.Set<CustomerContactEntity>()
            .Include(x => x.Customer)
            .Where(expression)
            .FirstOrDefaultAsync();
        
        if (result == null)
        {
            return null!;
        }
        return result;
    }
}
