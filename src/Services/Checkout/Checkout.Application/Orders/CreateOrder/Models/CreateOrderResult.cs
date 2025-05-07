namespace Checkout.Application.Orders.CreateOrder.Models;

/// <summary>
/// Represents the result of creating an order.
/// </summary>
/// <param name="Id"></param>
public sealed record CreateOrderResult(Guid Id);