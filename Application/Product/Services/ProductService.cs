using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Product.Contracts;

namespace Application.Product.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductPersistence _persistence;

        public ProductService(IProductPersistence persistence)
        {
            _persistence = persistence;
        }

        public (IProductEntity, Exception) GetById(string id)
        {
            var result = _persistence.Get(id);

            if (result.Item1 == null)
                return (null, result.Item2);

            return (result.Item1, null);
        }

        public (IProductEntity, Exception) Create(string name, decimal value)
        {
            var newProduct = new Product.Entity.ProductEntity(name, value);

            var isValid = newProduct.IsValid();

            if (isValid.isValid)
                return _persistence.Save(newProduct);

            return (null, isValid.exception);
        }

        public (IProductEntity, Exception) Enable(IProductEntity product)
        {
            try
            {
                product.Enable();

                return _persistence.Save(product);
            }
            catch (System.Exception ex)
            {
                return (null, ex);
            }
        }

        public (IProductEntity, Exception) Disable(IProductEntity product)
        {
            try
            {
                product.Disable();

                return _persistence.Save(product);
            }
            catch (System.Exception ex)
            {
                return (null, ex);
            }
        }
    }
}