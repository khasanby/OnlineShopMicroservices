namespace Checkout.Domain.ValueObjects;

public sealed record Payment
{
    /// <summary>
    /// Gets card name.
    /// </summary>
    public string? CardName { get; }

    /// <summary>
    /// Gets card number.
    /// </summary>
    public string CardNumber { get; }

    /// <summary>
    /// Gets card expiration date.
    /// </summary>
    public string Expiration { get; }

    /// <summary>
    /// Gets card CVV.
    /// </summary>
    public string CVV { get; }

    /// <summary>
    /// Gets payment method.
    /// </summary>
    public int PaymentMethod { get; }

    protected Payment()
    { }

    private Payment(string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
    {
        CardName = cardName;
        CardNumber = cardNumber;
        Expiration = expiration;
        CVV = cvv;
        PaymentMethod = paymentMethod;
    }

    public static Payment Of(string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(cardName);
        ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(cvv);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, 3);

        return new Payment(cardName, cardNumber, expiration, cvv, paymentMethod);
    }
}