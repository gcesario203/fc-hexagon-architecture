using Adapters.Product.Models;
using Microsoft.EntityFrameworkCore;

namespace Adapters.Shared.Database.InMemory
{
    public class InMemoryDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(optionsBuilder.IsConfigured)
                return;

            optionsBuilder.UseInMemoryDatabase(databaseName: "ProductDb");
        }

        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options)
        : base(options)
        { }
        
        public InMemoryDbContext(): base(){
            
        }

        public DbSet<ProductEntityFrameworkModel> Products { get; set; }
    }
}