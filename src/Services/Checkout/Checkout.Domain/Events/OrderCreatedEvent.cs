using Checkout.Domain.Abstractions.Base;
using Checkout.Domain.Entities;

namespace Checkout.Domain.Events;

/// <summary>
/// Represents an event that occurs when an order is created.
/// </summary>
/// <param name="Order"></param>
public sealed record OrderCreatedEvent(OrderDB Order) : IDomainEvent;