using Checkout.Domain.Abstractions;
using Checkout.Domain.ValueObjects;

namespace Checkout.Domain.Entities;

public sealed class CustomerDB : Entity<CustomerId>
{
    /// <summary>
    /// Gets or privately sets the unique identifier for the customer.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets or privately sets the email address of the customer.
    /// </summary>
    public string Email { get; private set; }

    public static CustomerDB Create(CustomerId customerId, string name, string email)
    {
        ArgumentNullException.ThrowIfNull(customerId);
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(email);
        
        return new CustomerDB
        {
            Id = customerId,
            Name = name,
            Email = email,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "System"
        };
    }
}