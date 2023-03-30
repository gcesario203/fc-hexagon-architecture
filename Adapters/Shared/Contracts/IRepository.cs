namespace Adapters.Shared.Contracts
{
    public interface IRepository<TData>
    {
        (TData, Exception) Get(string id);
    }
}