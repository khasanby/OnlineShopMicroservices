using BuildingBlocks.CQRS.Commands;
using Checkout.Application.Models;
using Checkout.Application.Orders.CreateOrder.Models;

namespace Checkout.Application.Orders.CreateOrder;

/// <summary>
/// Represents a command to create an order.
/// </summary>
/// <param name="Order"></param>
public sealed record CreateOrderCommand(Order Order) : ICommand<CreateOrderResult>;