namespace Checkout.API.Endpoints.Models.Update;

/// <summary>
/// Represent a response of an order update.
/// </summary>
/// <param name="IsSuccess"></param>
public sealed record UpdateOrderResponse(bool IsSuccess);