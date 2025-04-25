namespace Cart.API.Cart.CheckoutCart.Models;

/// <summary>
/// Response for Checkout Basket.
/// </summary>
/// <param name="IsSuccess"></param>
public sealed record CheckoutCartResponse(bool IsSuccess);