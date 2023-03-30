using Microsoft.EntityFrameworkCore;

namespace Adapters.Shared.Database.InMemory
{
    public class InMemoryDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ProductDb");
        }
    }
}