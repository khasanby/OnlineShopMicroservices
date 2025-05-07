using Checkout.Application.Models;

namespace Checkout.API.Endpoints.Models.Update;

/// <summary>
/// Represents a request to update an order.
/// </summary>
/// <param name="IsSuccess"></param>
public sealed record UpdateOrderRequest(Order Order);