using Coupon.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coupon.Domain.DataAccess;

public interface ICouponDbContext
{
    /// <summary>
    /// Gets or sets the DbSet of coupons in the database context.
    /// </summary>
    public DbSet<CouponDb> Coupons { get; set; }

    /// <summary>
    /// Saves all changes made in this context to the database.
    /// </summary>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}