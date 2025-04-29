using Coupon.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coupon.Infrastructure;

internal static class CouponDbContextExtensions
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CouponDb>().HasData(
            new CouponDb
            {
                Id = Guid.NewGuid(),
                ProductName = "Product 1",
                Description = "Description 1",
                Amount = 10
            },
            new CouponDb
            {
                Id = Guid.NewGuid(),
                ProductName = "Product 2",
                Description = "Description 2",
                Amount = 20
            },
            new CouponDb
            {
                Id = Guid.NewGuid(),
                ProductName = "Product 3",
                Description = "Description 3",
                Amount = 30
            }
        );
    }
}