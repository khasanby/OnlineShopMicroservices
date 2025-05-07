using Checkout.Domain.Abstractions.Base;

namespace Checkout.Domain.Abstractions;

public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
{
    /// <summary>
    /// Private field to store the domain events associated with the aggregate.
    /// </summary>
    private readonly List<IDomainEvent> _domainEvents = new();


    /// <summary>
    /// Gets the domain events associated with the aggregate.
    /// </summary>
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();


    /// <summary>
    /// Adds a domain event to the aggregate.
    /// </summary>
    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        if (domainEvent is null)
            throw new ArgumentNullException(nameof(domainEvent));
        
        _domainEvents.Add(domainEvent);
    }

    /// <summary>
    /// Clears the domain events from the aggregate.
    /// </summary>
    public void ClearDomainEvents()
    {
        if (_domainEvents.Count == 0)
            return;

        _domainEvents.Clear();
    }
}