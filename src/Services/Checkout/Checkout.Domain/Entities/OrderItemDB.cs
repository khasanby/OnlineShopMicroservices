using Checkout.Domain.Abstractions;
using Checkout.Domain.ValueObjects;

namespace Checkout.Domain.Entities;

public sealed class OrderItemDB : Entity<OrderItemId>
{
    internal OrderItemDB(OrderId orderId, ProductId productId, int quantity, decimal price)
    {
        Id = OrderItemId.Of(Guid.NewGuid());
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }

    /// <summary>
    /// Gets or privately sets the unique identifier for the order item.
    /// </summary>
    public OrderId OrderId { get; private set; }

    /// <summary>
    /// Gets or privately sets the unique identifier for the product.
    /// </summary>
    public ProductId ProductId { get; private set; }

    /// <summary>
    /// Gets or privately sets the quantity of the product in the order item.
    /// </summary>
    public int Quantity { get; private set; }

    /// <summary>
    /// Gets or privately sets the price of the product in the order item.
    /// </summary>
    public decimal Price { get; private set; }
}
