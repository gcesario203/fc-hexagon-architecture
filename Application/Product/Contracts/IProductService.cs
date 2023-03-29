namespace Application.Product.Contracts
{
    public interface IProductService
    {
        IProduct GetById(string id);

        (IProduct, Exception) Create(string name, decimal value);

        (IProduct, Exception) Enable(IProduct product);

        (IProduct, Exception) Disable(IProduct product);
    }
}