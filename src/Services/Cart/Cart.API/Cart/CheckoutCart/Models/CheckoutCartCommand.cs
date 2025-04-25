using Cart.API.Models;

namespace Cart.API.Cart.CheckoutCart.Models;

/// <summary>
/// Represents a command to checkout a shopping cart.
/// </summary>
/// <param name="cartCheckout"></param>
public sealed record CheckoutCartCommand(CartCheckout CartCheckout) : ICommand<CheckoutCartResult>;