using Application.Product.Contracts;
using Microsoft.EntityFrameworkCore;
using Adapters.Product.Models;
using AutoMapper;
using Adapters.Shared.Abstractions;

namespace Adapters.Product.Adapters
{
    public class ProductAdapter : BaseAdapter, IProductPersistence
    {

        public ProductAdapter() : base()
        {
        }

        public ProductAdapter(DbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }

        public (IProduct, Exception) Get(string id)
        {
            try
            {
                var result = _context.Set<ProductEntityFrameworkModel>().FirstOrDefault(x => x.Id == id);

                if(result != null)
                    return (_autoMapper.Map<Application.Product.Entity.Product>(result), null);

                return (null, new Exception("Product not found"));
            }
            catch (System.Exception ex)
            {
                return (null, ex);
            }
        }

        public (IProduct, Exception) Save(IProduct product)
        {
            try
            {
                _context.Set<ProductEntityFrameworkModel>().Add(_autoMapper.Map<ProductEntityFrameworkModel>(product));

                _context.SaveChanges();

                return (product, null);
            }
            catch (System.Exception ex)
            {
                return (null, ex);
            }
        }
    }
}