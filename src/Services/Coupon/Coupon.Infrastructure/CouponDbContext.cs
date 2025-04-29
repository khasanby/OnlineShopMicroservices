using Coupon.Domain.DataAccess;
using Coupon.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coupon.Infrastructure;

public class CouponDbContext : DbContext, ICouponDbContext
{
    public CouponDbContext(DbContextOptions<CouponDbContext> options) : base(options)
    { }

    public DbSet<CouponDb> Coupons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.SeedData();
    }
}