namespace Cart.API.Cart.StoreCart.Models;

/// <summary>
/// Represents the result of storing a shopping cart.
/// </summary>
/// <param name="Username"></param>
public sealed record StoreCartResult(string Username);