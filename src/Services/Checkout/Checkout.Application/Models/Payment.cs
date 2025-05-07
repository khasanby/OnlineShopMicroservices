namespace Checkout.Application.Models;

public sealed record Payment(
    string CardName,
    string CardNumber,
    string Expiration,
    string Cvv,
    int PaymentMethod
);