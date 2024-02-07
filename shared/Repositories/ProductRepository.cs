using Microsoft.EntityFrameworkCore;
using shared.Contexts;
using shared.Entities;
using System.Linq.Expressions;

namespace shared.Repositories;

public class ProductRepository : BaseRepository<ProductEntity>
{
    private readonly DataContext _context;
    public ProductRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override IEnumerable<ProductEntity> GetAll()
    {
        return _context.Products
            .Include(i => i.Category)
            .Include(i => i.Manufacture)
            .ToList();
    }

    public override ProductEntity GetOne(Expression<Func<ProductEntity, bool>> expression)
    {
        var entity = _context.Products
            .Include(i => i.Category)
            .Include(i => i.Manufacture)
            .FirstOrDefault(expression);
        return entity!;
    }
}