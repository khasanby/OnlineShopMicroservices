using Checkout.Domain.DataAccess;
using Checkout.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Checkout.Infrastructure.DataAccess;

public class CheckoutDbContext : DbContext, ICheckoutDbContext
{
    /// <summary>
    /// Customers DbSet property to access the customers in the database.
    /// </summary>
    public DbSet<CustomerDB> Customers { get; set; }

    /// <summary>
    /// Products DbSet property to access the products in the database.
    /// </summary>
    public DbSet<ProductDB> Products { get; set; }

    /// <summary>
    /// Orders DbSet property to access the orders in the database.
    /// </summary>
    public DbSet<OrderDB> Orders { get; set; }

    /// <summary>
    /// OrderItems DbSet property to access the order items in the database.
    /// </summary>
    public DbSet<OrderItemDB> OrderItems { get; set; }

    public CheckoutDbContext(DbContextOptions<CheckoutDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}