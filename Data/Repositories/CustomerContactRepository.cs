using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class CustomerContactRepository(DataContext context) : BaseRepository<CustomerContactEntity>(context), ICustomerContactRepository
{
    
    public override async Task<IEnumerable<CustomerContactEntity>> GetAllAsync()
    {
        return await _context.Set<CustomerContactEntity>()
            .Include(x => x.Customer)
            .ToListAsync();
    }
}
