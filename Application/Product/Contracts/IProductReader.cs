namespace Application.Product.Contracts
{
    public interface IProductReader
    {
        (IProduct, Exception) Get(string id); 
    }
}