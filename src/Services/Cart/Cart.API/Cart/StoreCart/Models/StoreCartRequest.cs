namespace Cart.API.Cart.StoreCart.Models;

/// <summary>
/// Represents a request to store a shopping cart.
/// </summary>
/// <param name="Cart"></param>
public sealed record StoreCartRequest(ShoppingCart Cart);