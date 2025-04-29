using Coupon.Domain.Entities;

namespace Coupon.Domain.DataAccess.Extensions;

public static class CouponQueryableExtensions
{
    /// <summary>
    /// Filters the coupons based on the minimum discount amount and an optional product name.
    /// </summary>
    public static IQueryable<CouponDb> WhereDiscountIsAtLeast(
        this IQueryable<CouponDb> query,
        int minAmount,
        string? productName = null)
    {
        if(!string.IsNullOrEmpty(productName))
        {
            query = query.Where(c =>
                c.Amount >= minAmount &&
                string.Equals(c.ProductName.ToLower(), productName.ToLower()));
        }
        else
            query = query.Where(c => c.Amount >= minAmount);

        return query;
    }
}