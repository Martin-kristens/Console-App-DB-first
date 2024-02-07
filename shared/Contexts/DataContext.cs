using Microsoft.EntityFrameworkCore;
using shared.Entities;

namespace shared.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<ManufactureEntity> Manufactures { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
}
