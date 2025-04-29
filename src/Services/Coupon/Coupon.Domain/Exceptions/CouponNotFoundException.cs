using BuildingBlocks.Exceptions;

namespace Coupon.Domain.Exceptions;

public sealed class CouponNotFoundException : BaseException
{
    public override string ErrorCode => "NOT_FOUND";
    public override int StatusCode => 404;

    public CouponNotFoundException() { }

    public CouponNotFoundException(string? message) : base(message) { }

    public CouponNotFoundException(string? message, Exception innerException)
        : base(message, innerException) { }
}