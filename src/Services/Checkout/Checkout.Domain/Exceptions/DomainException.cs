using BuildingBlocks.Exceptions;

namespace Checkout.Domain.Exceptions;

public sealed class DomainException : BaseException
{
    public DomainException(string message)
        : base($"Domain Exception: \"{message}\" throws from Domain Layer.")
    {
    }

    public DomainException(string? message, Exception innerException) : base(message, innerException)
    {
    }

    public override string ErrorCode => "DomainException";
    public override int StatusCode => 400;
}