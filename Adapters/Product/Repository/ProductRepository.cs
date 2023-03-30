using Adapters.Product.Contracts;
using Application.Product.Contracts;
using Microsoft.EntityFrameworkCore;
using Adapters.Shared.Database.InMemory;

namespace Adapters.Product.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbContext _context;

        public ProductRepository()
        {
            _context = new InMemoryDbContext();
        }
        public (IProduct, Exception) Get(string id)
        {
            try
            {
                return (_context.Set<Application.Product.Entity.Product>().FirstOrDefault(x => x.GetId() == id), null);
            }
            catch (System.Exception ex)
            {
                return (null, ex);
            }
        }

        public (IProduct, Exception) Save(string name, decimal value)
        {
            try
            {
                var newProduct = new Application.Product.Entity.Product(name, value);

                _context.Set<Application.Product.Entity.Product>().Add(newProduct);

                _context.SaveChanges();

                return (newProduct, null);
            }
            catch (System.Exception ex)
            {
                return (null, ex);
            }
        }
    }
}