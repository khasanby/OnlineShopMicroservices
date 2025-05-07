using BuildingBlocks.Pagination;
using Checkout.Application.Models;

namespace Checkout.API.Endpoints.Models.Get;

/// <summary>
/// Represents the response for the GetOrders endpoint.
/// </summary>
/// <param name="Orders"></param>
public sealed record GetOrdersResponse(PaginatedResult<Order> Orders);