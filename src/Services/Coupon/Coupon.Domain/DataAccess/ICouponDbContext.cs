using Coupon.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coupon.Domain.DataAccess;

public interface ICouponDbContext
{
    public DbSet<CouponDb> Coupons { get; set; }
}