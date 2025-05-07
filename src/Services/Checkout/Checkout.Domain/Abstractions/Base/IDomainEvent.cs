using MediatR;

namespace Checkout.Domain.Abstractions.Base;

public interface IDomainEvent : INotification
{
    /// <summary>
    /// Gets the unique identifier for the event.
    /// </summary>
    Guid EventId => Guid.NewGuid();

    /// <summary>
    /// Gets the date and time when the event occurred.
    /// </summary>
    public DateTime OccurredOn => DateTime.Now;

    /// <summary>
    /// Gets the type of the event.
    /// </summary>
    public string? EventType => GetType().AssemblyQualifiedName;
}