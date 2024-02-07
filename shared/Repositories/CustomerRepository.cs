using Microsoft.EntityFrameworkCore;
using shared.Contexts;
using shared.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace shared.Repositories;

public class CustomerRepository : BaseRepository<CustomerEntity>
{
    private readonly DataContext _context;

    public CustomerRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override IEnumerable<CustomerEntity> GetAll()
    {
        return _context.Customers
            .Include(i => i.Address)
            .ToList();
    }

    public override CustomerEntity GetOne(Expression<Func<CustomerEntity, bool>> expression)
    {
        var entity = _context.Customers
            .Include(i => i.Address)
            .FirstOrDefault(expression);
        return entity!;
    }
}
