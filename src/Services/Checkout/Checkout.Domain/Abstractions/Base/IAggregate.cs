namespace Checkout.Domain.Abstractions.Base;

public interface IAggregate<TId> : IAggregate, IEntity<TId>
{ }

public interface IAggregate : IEntity
{
    /// <summary>
    /// Gets the domain events associated with the aggregate.
    /// </summary>
    public IReadOnlyList<IDomainEvent> DomainEvents { get; }

    /// <summary>
    /// Adds a domain event to the aggregate.
    /// </summary>
    /// <param name="domainEvent"></param>
    public void AddDomainEvent(IDomainEvent domainEvent);

    /// <summary>
    /// Clears the domain events from the aggregate.
    /// </summary>
    public void ClearDomainEvents();
}