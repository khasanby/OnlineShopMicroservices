namespace Cart.API.Exceptions;

public sealed class CartNotFoundException : BaseException
{
    public override string ErrorCode => "NOT_FOUND";
    public override int StatusCode => 404;

    public CartNotFoundException(string errorName)
        : base(errorName)
    {
    }

    public CartNotFoundException(string entityName, object key)
        : base($"{entityName} with ID '{key}' was not found.")
    {
    }
}