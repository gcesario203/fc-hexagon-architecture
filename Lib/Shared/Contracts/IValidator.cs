namespace Lib.Shared.Contracts
{
    public interface IValidator
    {
        IEnumerable<string> GetEmptyRequiredFields();

        protected (bool isValid, Exception? exception) IsValid();
    }
}