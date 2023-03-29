namespace Application.Product.Contracts
{
    public interface IProductWriter
    {
        (IProduct, Exception) Save(IProduct product);
    }
}