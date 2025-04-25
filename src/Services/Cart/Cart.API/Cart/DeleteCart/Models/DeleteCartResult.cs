namespace Cart.API.Cart.DeleteCart.Models;

/// <summary>
/// Represents the result of a delete cart operation.
/// </summary>
/// <param name="IsSuccess"></param>
public sealed record DeleteCartResult(bool IsSuccess);