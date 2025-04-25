using Cart.API.Cart.CheckoutCart.Models;
using Cart.API.Data;
using Mapster;

namespace Cart.API.Cart.CheckoutCart;

public sealed class CheckoutCartCommandHandler : ICommandHandler<CheckoutCartCommand, CheckoutCartResult>
{
    private readonly ICartRepository _cartRepository;

    public CheckoutCartCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<CheckoutCartResult> Handle(CheckoutCartCommand command, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetCartAsync(command.CartCheckout.UserName, cancellationToken);
        if (cart == null)
        {
            return new CheckoutCartResult(false);
        }

        //var eventMessage = command.CartCheckout.Adapt<CartCheckoutEvent>();
        //eventMessage.TotalPrice = cart.TotalPrice;

        //await publishEndpoint.Publish(eventMessage, cancellationToken);

        await _cartRepository.DeleteCartAsync(command.CartCheckout.UserName, cancellationToken);

        return new CheckoutCartResult(true);
    }

}