namespace Cart.API.Cart.GetCart.Models;

/// <summary>
/// Result of the GetCart operation.
/// </summary>
/// <param name="Cart"></param>
public sealed record GetCartResult(ShoppingCart Cart);