using Coupon.Domain.DataAccess;
using Coupon.Domain.Entities;
using Coupon.Grpc;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Coupon.Application.Services;

public sealed class CouponService(ICouponDbContext dbContext, ILogger<CouponService> logger)
    : CouponProtoService.CouponProtoServiceBase
{
    // TODO: CouponDB shouldn't be used in the service layer.
    // Repository layer will be created and the logic will be moved there.
    public override async Task<CouponModel> GetCoupon(GetCouponRequest request, ServerCallContext context)
    {
        var coupon = await dbContext
            .Coupons
            .FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

        if (coupon is null)
            coupon = new CouponDb { ProductName = "No Coupon", Amount = 0, Description = "No Coupon Desc" };

        logger.LogInformation("Coupon is retrieved for ProductName : {productName}, Amount : {amount}", coupon.ProductName, coupon.Amount);

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }

    public override async Task<CouponModel> CreateCoupon(CreateCouponRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<CouponModel>();
        if (coupon is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));

        var couponDb = coupon.Adapt<CouponDb>();
        dbContext.Coupons.Add(couponDb);
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Coupon is successfully created. ProductName : {ProductName}", coupon.ProductName);

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }


    public override async Task<CouponModel> UpdateCoupon(UpdateCouponRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<CouponModel>();
        if (coupon is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));

        var couponDb = coupon.Adapt<CouponDb>();
        dbContext.Coupons.Update(couponDb);
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Coupon is successfully updated. ProductName : {ProductName}", coupon.ProductName);

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }

    public override async Task<DeleteCouponResponse> DeleteCoupon(DeleteCouponRequest request, ServerCallContext context)
    {
        var coupon = await dbContext
            .Coupons
            .FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

        if (coupon is null)
            throw new RpcException(new Status(StatusCode.NotFound, $"Coupon with ProductName={request.ProductName} is not found."));

        dbContext.Coupons.Remove(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation("Coupon is successfully deleted. ProductName : {ProductName}", request.ProductName);

        return new DeleteCouponResponse { Success = true };
    }
}