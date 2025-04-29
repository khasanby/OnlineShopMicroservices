namespace Coupon.Application.Models;

public sealed class Coupon
{
    /// <summary>
    /// Gets or sets the unique identifier for the user associated with the coupon.
    /// </summary>
    public string ProductName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the description of the coupon.
    /// </summary>
    public string Description { get; set; } = default!;

    /// <summary>
    /// Gets or sets the discount amount of the coupon.
    /// </summary>
    public int Amount { get; set; }
}