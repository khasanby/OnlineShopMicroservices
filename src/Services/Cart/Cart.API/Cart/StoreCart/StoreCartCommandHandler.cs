using Cart.API.Cart.StoreCart.Models;
using Cart.Domain.Data;
using Cart.Domain.Entities;
using Coupon.Grpc;

namespace Cart.API.Cart.StoreCart;

public sealed class StoreCartCommandHandler : ICommandHandler<StoreCartCommand, StoreCartResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly CouponProtoService.CouponProtoServiceClient _couponProto;

    public StoreCartCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<StoreCartResult> Handle(StoreCartCommand command, CancellationToken cancellationToken)
    {

        Task[] discountTasks = CalculateDiscount(command.Cart, cancellationToken);
        await Task.WhenAll(discountTasks);
        await _cartRepository.StoreCartAsync(command.Cart, cancellationToken);

        return new StoreCartResult(command.Cart.Username);
    }

    private Task[] CalculateDiscount(ShoppingCart cart, CancellationToken cancellationToken)
    {
        return cart.Items.Select(async item =>
        {
            var coupon = await _couponProto.GetCouponAsync(
                new GetCouponRequest { ProductName = item.ProductName },
                cancellationToken: cancellationToken);
            item.Price -= coupon.Amount;
        }).ToArray();
    }
}