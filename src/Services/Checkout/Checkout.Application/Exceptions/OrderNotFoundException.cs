using BuildingBlocks.Exceptions;

namespace Checkout.Application.Exceptions;

public sealed class OrderNotFoundException : BaseException
{
    public override string ErrorCode => "NOT_FOUND";
    public override int StatusCode => 404;

    public OrderNotFoundException() { }

    public OrderNotFoundException(string? message) : base(message) { }

    public OrderNotFoundException(string? message, Exception innerException)
        : base(message, innerException) { }
}