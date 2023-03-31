namespace Application.Product.Contracts
{
    public interface IProductReader
    {
        (IProductEntity, Exception) Get(string id); 
    }
}