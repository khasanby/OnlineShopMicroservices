using Checkout.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Checkout.Domain.DataAccess;

public interface ICheckoutDbContext
{
    public DbSet<CustomerDB> Customers { get; set; }
    public DbSet<ProductDb> Products { get; set; }
    public DbSet<OrderDb> Orders { get; set; }
    public DbSet<OrderItemDb> OrderItems { get; set; }
}