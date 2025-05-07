using Checkout.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Checkout.Domain.DataAccess;

public interface ICheckoutDbContext
{
    /// <summary>
    /// Gets or sets the DbSet of customers in the database.
    /// </summary>
    public DbSet<CustomerDB> Customers { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of products in the database.
    /// </summary>
    public DbSet<ProductDB> Products { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of orders in the database.
    /// </summary>
    public DbSet<OrderDB> Orders { get; set; }

    /// <summary>
    /// Gets or sets the DbSet of order items in the database.
    /// </summary>
    public DbSet<OrderItemDB> OrderItems { get; set; }

    /// <summary>
    /// Asynchronously saves changes to the database.
    /// </summary>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}