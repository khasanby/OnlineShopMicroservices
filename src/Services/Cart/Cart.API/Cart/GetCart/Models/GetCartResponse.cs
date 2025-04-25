namespace Cart.API.Cart.GetCart.Models;

/// <summary>
/// Represents the response for the GetCart endpoint.
/// </summary>
/// <param name="Cart"></param>
public sealed record GetCartResponse(ShoppingCart Cart);