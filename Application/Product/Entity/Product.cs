using Application.Product.Contracts;
using Application.Shared.Abstractions;
using Application.Shared.Attributes;

namespace Application.Product.Entity
{
    public class Product : BaseValidator, IProduct
    {
        private string Id;

        [RequiredFieldAttribute]
        private string Name;

        private string Status;

        private decimal Price;

        public Product(string name, decimal price, string id = null)
        {
            Name = name;
            Price = price;

            Id = string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id;

            Status = Shared.Constants.Status.DISABLED;

            var validateResult = IsValid();

            if(!validateResult.isValid && validateResult.exception != null)
                throw validateResult.exception;
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

        public override (bool isValid, Exception? exception) IsValid()
        {
            var baseValidation = base.IsValid();

            if(baseValidation.isValid == false)
                return (baseValidation);

            if(!Guid.TryParse(this.Id, out var result))
                return (false, new Exception("Invalid GUID!"));

            if(string.IsNullOrEmpty(GetStatus()))
                Status = Shared.Constants.Status.DISABLED;

            if(GetStatus() != Shared.Constants.Status.DISABLED && GetStatus() != Shared.Constants.Status.ENABLED)
                return (false, new Exception("The Status must be ENABLED or DISABLED"));

            if(GetPrice() < 0)
                return (false, new Exception("The price must be greater or equal zero"));

            return (true, null);
        }
    }
}