namespace Inventory.API.Infrastructure.Exceptions;

public sealed class ProductNotFoundException : BaseException
{
    public override string ErrorCode => "NOT_FOUND";
    public override int StatusCode => 404;

    public ProductNotFoundException(string errorName)
        : base(errorName)
    {
    }

    public ProductNotFoundException(string entityName, object key)
        : base($"{entityName} with ID '{key}' was not found.")
    {
    }
}