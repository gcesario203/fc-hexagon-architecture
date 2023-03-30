using Adapters.Shared.Contracts;
using Application.Product.Contracts;

namespace Adapters.Product.Contracts
{
    public interface IProductRepository : IRepository<IProduct>
    {
        (IProduct, Exception) Save(string name, decimal value);
    }
}