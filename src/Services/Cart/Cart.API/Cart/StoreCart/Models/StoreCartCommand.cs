namespace Cart.API.Cart.StoreCart.Models;

/// <summary>
/// Represents a command to store a shopping cart.
/// </summary>
/// <param name="Cart"></param>
public sealed record StoreCartCommand(ShoppingCart Cart) : ICommand<StoreCartResult>;