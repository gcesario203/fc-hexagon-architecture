using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adapters.Product.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }

        public decimal Value { get; set; }

        public ProductDTO()
        {
            
        }
        public ProductDTO(string name, decimal value)
        {
            Name = name;
            Value = value;
        }

        public void Validate(){
            if(string.IsNullOrEmpty(Name))
                throw new Exception("Product name cannot be null or empty");

            if(Value < 0)
                throw new Exception("Product Value cannot be less than zero");
        }
    }
}