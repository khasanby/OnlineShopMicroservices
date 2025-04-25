namespace Cart.API.Cart.CheckoutCart.Models;

/// <summary>
/// Represents the result of a checkout cart operation.
/// </summary>
/// <param name="IsSuccess"></param>
public sealed record CheckoutCartResult(bool IsSuccess);