﻿using Checkout.Domain.Abstractions.Base;
using Checkout.Domain.Entities;

namespace Checkout.Domain.Events;

/// <summary>
/// Represents an event that is triggered when an order is updated.
/// </summary>
/// <param name="Order"></param>
public sealed record OrderUpdatedEvent(OrderDB Order) : IDomainEvent;