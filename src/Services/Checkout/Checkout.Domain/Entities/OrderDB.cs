using Checkout.Domain.Abstractions;
using Checkout.Domain.Enums;
using Checkout.Domain.Events;
using Checkout.Domain.ValueObjects;

namespace Checkout.Domain.Entities;

public sealed class OrderDb : Aggregate<OrderId>
{
    /// <summary>
    /// Private field to store the list of order items associated with the order.
    /// </summary>
    private readonly List<OrderItemDB> _orderDbItems = new();


    /// <summary>
    /// Gets the order items associated with the order.
    /// </summary>
    public IReadOnlyList<OrderItemDB> OrderItems => _orderDbItems.AsReadOnly();

    /// <summary>
    /// Gets or privately sets the unique identifier for the order.
    /// </summary>
    public CustomerId CustomerId { get; private set; } = default!;

    /// <summary>
    /// Gets or privately sets the name of the order.
    /// </summary>
    public OrderName OrderName { get; private set; } = default!;

    /// <summary>
    /// Gets or privately sets the shipping address for the order.
    /// </summary>
    public Address ShippingAddress { get; private set; } = default!;

    /// <summary>
    /// Gets or privately sets the billing address for the order.
    /// </summary>
    public Address BillingAddress { get; private set; } = default!;

    /// <summary>
    /// Gets or privately sets the payment information for the order.
    /// </summary>
    public Payment Payment { get; private set; } = default!;

    /// <summary>
    /// Gets or privately sets the status of the order.
    /// </summary>
    public OrderStatus Status { get; private set; } = OrderStatus.Pending;

    /// <summary>
    /// Gets or privately sets the total price of the order.
    /// </summary>
    public decimal TotalPrice
    {
        get => OrderItems.Sum(x => x.Price * x.Quantity);
        private set { }
    }

    /// <summary>
    /// Creates a new instance of the OrderDb class with the specified details.
    /// </summary>
    public static OrderDb Create(OrderId id, CustomerId customerId, OrderName orderName, Address shippingAddress, Address billingAddress, Payment payment)
    {
        var order = new OrderDb
        {
            Id = id,
            CustomerId = customerId,
            OrderName = orderName,
            ShippingAddress = shippingAddress,
            BillingAddress = billingAddress,
            Payment = payment,
            Status = OrderStatus.Pending
        };

        order.AddDomainEvent(new OrderCreatedEvent(order));

        return order;
    }

    /// <summary>
    /// Updates the order with the specified details.
    /// </summary>
    public void Update(OrderName orderName, Address shippingAddress, Address billingAddress, Payment payment, OrderStatus status)
    {
        OrderName = orderName;
        ShippingAddress = shippingAddress;
        BillingAddress = billingAddress;
        Payment = payment;
        Status = status;

        AddDomainEvent(new OrderUpdatedEvent(this));
    }

    public void Add(ProductId productId, int quantity, decimal price)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        var orderItem = new OrderItemDB(Id, productId, quantity, price);
        _orderDbItems.Add(orderItem);
    }

    public void Remove(ProductId productId)
    {
        var orderItem = _orderDbItems.FirstOrDefault(x => x.ProductId == productId);
        if (orderItem is not null)
        {
            _orderDbItems.Remove(orderItem);
        }
    }
}
