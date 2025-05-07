using Checkout.Domain.Exceptions;

namespace Checkout.Domain.ValueObjects;

public class OrderItemId
{
    /// <summary>
    /// Gets the value of unique identifier for the order item.
    /// </summary>
    public Guid Value { get; }

    private OrderItemId(Guid value)
    {
        Value = value;
    }

    public static OrderItemId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        if (value == Guid.Empty)
            throw new DomainException("Order item ID cannot be empty.");
        
        return new OrderItemId(value);
    }
}