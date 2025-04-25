namespace Cart.API.Cart.GetCart.Models;

/// <summary>
/// Query to get the cart.
/// </summary>
/// <param name="Username"></param>
public sealed record GetCartQuery(string Username) : IQuery<GetCartResult>;