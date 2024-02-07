using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using shared.Contexts;

namespace shared.Factories;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Education\CSharp\VisualStudio\Console-App-DB-first\shared\Data\console-db.mdf;Integrated Security=True;Connect Timeout=30");

        return new DataContext(optionsBuilder.Options);
    }
}
