using Lib.Product.Contracts;

namespace Lib.Product.Entity
{
    public class Product : IProduct
    {
        private string Id;

        private string Name;

        private string Status;

        private decimal Price;

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;

            Id = Guid.NewGuid().ToString();

            Status = Shared.Constants.Status.DISABLED;
        }

        public void Disable(){
            if(GetPrice() == 0){
                Status = Shared.Constants.Status.DISABLED;

                return;
            }

            throw new Exception("The price must be zero in order to disable a product");
        }

        public void Enable()
        {
            if (GetPrice() > 0)
            {
                Status = Shared.Constants.Status.ENABLED;

                return;
            }

            throw new Exception("The price must be greater than zero");
        }
        public string GetId()
            => Id;

        public string GetName()
            => Name;

        public decimal GetPrice()
            => Price;

        public string GetStatus()
            => Status;

        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}