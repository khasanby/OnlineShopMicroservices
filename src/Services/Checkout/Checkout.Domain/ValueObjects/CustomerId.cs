using Checkout.Domain.Exceptions;

namespace Checkout.Domain.ValueObjects;

public sealed record CustomerId
{
    /// <summary>
    /// Gets the value of the <see cref="CustomerId"/> as a <see cref="Guid"/> type.
    /// </summary>
    public Guid Value { get; }

    /// <summary>
    /// Private constructor to create a new instance of <see cref="CustomerId"/> with a <see cref="Guid"/> value.
    /// </summary>
    private CustomerId(Guid value) => Value = value;

    /// <summary>
    /// Creates a new instance of <see cref="CustomerId"/> from a <see cref="Guid"/> value.
    /// </summary>
    public static CustomerId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("CustomerId cannot be empty.");
        }

        return new CustomerId(value);
    }
}