
using Adapters.Shared.Contracts;

namespace Adapters.Product.Models
{
    public class ProductEntityFrameworkModel : BaseEntityFrameworkModel
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public string Price { get; set; }
    }
}