using Checkout.Domain.Exceptions;

namespace Checkout.Domain.ValueObjects;

public sealed record OrderId
{
    /// <summary>
    /// Gets a Value object representing the order ID.
    /// </summary>
    public Guid Value { get; }

    /// <summary>
    /// Initializes value object with a new GUID.
    /// Private constructor used to prevent instantiation from outside.
    /// </summary>
    private OrderId(Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Creates a new instance of OrderId with a new GUID.
    /// </summary>
    public static OrderId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        if (value == Guid.Empty)
            throw new DomainException("Order ID cannot be empty.");

        return new OrderId(value);
    }
}