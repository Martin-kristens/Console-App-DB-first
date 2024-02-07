using shared.Contexts;
using shared.Entities;

namespace shared.Repositories;

public class CategoryRepository : BaseRepository<CategoryEntity>
{
    public CategoryRepository(DataContext context) : base(context)
    {
    }
}
