using Checkout.Application.Models;

namespace Checkout.API.Endpoints.Models.Get;

/// <summary>
/// Represents a response model for retrieving orders by name.
/// </summary>
/// <param name="Orders"></param>
public sealed record GetOrdersByNameResponse(IEnumerable<Order> Orders);