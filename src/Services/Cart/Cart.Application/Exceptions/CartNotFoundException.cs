using BuildingBlocks.Exceptions;

namespace Cart.Application.Exceptions;

public sealed class CartNotFoundException : BaseException
{
    public override string ErrorCode => "NOT_FOUND";
    public override int StatusCode => 404;

    public CartNotFoundException() { }

    public CartNotFoundException(string? message) : base(message) { }

    public CartNotFoundException(string? message, Exception innerException)
        : base(message, innerException) { }
}