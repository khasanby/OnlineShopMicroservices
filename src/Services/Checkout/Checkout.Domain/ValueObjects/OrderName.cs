namespace Checkout.Domain.ValueObjects;

public sealed record OrderName
{
    private const int MinLength = 5;

    public string Value { get; }

    private OrderName(string value) => Value = value;

    public static OrderName Of(string value)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(value, nameof(value));
        if (value.Length < MinLength)
        {
            throw new ArgumentException($"Order name must be at least {MinLength} characters long.", nameof(value));
        }

        return new OrderName(value);
    }
}