namespace Application.Product.Contracts
{
    public interface IProductWriter
    {
        (IProductEntity, Exception) Save(IProductEntity product);
    }
}