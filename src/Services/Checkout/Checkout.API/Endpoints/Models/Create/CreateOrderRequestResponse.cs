using Checkout.Application.Models;

namespace Checkout.API.Endpoints.Models.Create;

/// <summary>
/// Represents the response for creating an order.
/// </summary>
public sealed record CreateOrderRequest(Order Order);

/// <summary>
/// Represents the response for creating an order.
/// </summary>
public sealed record CreateOrderResponse(Guid orderId);