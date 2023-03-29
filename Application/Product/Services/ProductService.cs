using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Product.Contracts;

namespace Application.Product.Services
{
    public class ProductService
    {
        private readonly IProductPersistence _persistence;

        public ProductService(IProductPersistence persistence)
        {
            _persistence = persistence;
        }

        public (IProduct, Exception) Get(string id){
            var result = _persistence.Get(id);

            if(result.Item1 == null)
                return (null, result.Item2);

            return (result.Item1, null);
        }
    }
}