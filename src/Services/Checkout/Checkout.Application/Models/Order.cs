using Checkout.Domain.Enums;

namespace Checkout.Application.Models;

public sealed record Order(
    Guid Id,
    Guid CustomerId,
    string OrderName,
    Address ShippingAddress,
    Address BillingAddress,
    Payment Payment,
    OrderStatus Status,
    List<OrderItem> OrderItems
);