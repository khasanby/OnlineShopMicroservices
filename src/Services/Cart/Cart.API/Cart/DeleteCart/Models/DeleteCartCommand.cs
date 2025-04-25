namespace Cart.API.Cart.DeleteCart.Models;

/// <summary>
/// DeleteCartCommand is a command that represents a request to delete a cart.
/// </summary>
/// <param name="Username"></param>
public sealed record DeleteCartCommand(string Username) : ICommand<DeleteCartResult>;