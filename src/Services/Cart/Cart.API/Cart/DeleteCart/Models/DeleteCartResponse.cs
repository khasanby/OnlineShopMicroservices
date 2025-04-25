namespace Cart.API.Cart.DeleteCart.Models;

/// <summary>
/// Response model for deleting a cart.
/// </summary>
/// <param name="IsSuccess"></param>
public sealed record DeleteCartResponse(bool IsSuccess);