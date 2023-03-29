using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Product.Contracts
{
    public interface IProductPersistence : IProductReader, IProductWriter
    {
        
    }
}