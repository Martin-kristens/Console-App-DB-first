using shared.Contexts;
using shared.Entities;

namespace shared.Repositories;

public class AddressRepository : BaseRepository<AddressEntity>
{
    public AddressRepository(DataContext context) : base(context)
    {
    }
}
