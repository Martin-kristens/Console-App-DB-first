using shared.Contexts;
using shared.Entities;

namespace shared.Repositories;

public class ManufactureRepository : BaseRepository<ManufactureEntity>
{
    public ManufactureRepository(DataContext context) : base(context)
    {
    }
}
