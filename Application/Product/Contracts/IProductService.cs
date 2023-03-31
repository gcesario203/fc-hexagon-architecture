namespace Application.Product.Contracts
{
    public interface IProductService
    {
        (IProductEntity, Exception) GetById(string id);

        (IProductEntity, Exception) Create(string name, decimal value);

        (IProductEntity, Exception) Enable(IProductEntity product);

        (IProductEntity, Exception) Disable(IProductEntity product);
    }
}