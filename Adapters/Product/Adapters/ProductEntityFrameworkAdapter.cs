using Application.Product.Contracts;
using Microsoft.EntityFrameworkCore;
using Adapters.Product.Models;
using AutoMapper;
using Adapters.Shared.Abstractions;
using Application.Product.Entity;

namespace Adapters.Product.Adapters
{
    public class ProductEntityFrameworkAdapter : BaseEntityFrameworkAdapter, IProductPersistence
    {

        public ProductEntityFrameworkAdapter() : base()
        {
        }

        public ProductEntityFrameworkAdapter(DbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }

        public (IProductEntity, Exception) Get(string id)
        {
            try
            {
                var result = _context.Set<ProductEntityFrameworkModel>().FirstOrDefault(x => x.Id == id);

                if(result != null)
                    return (_autoMapper.Map<ProductEntity>(result), null);

                return (null, new Exception("Product not found"));
            }
            catch (System.Exception ex)
            {
                return (null, ex);
            }
        }

        public (IProductEntity, Exception) Save(IProductEntity product)
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