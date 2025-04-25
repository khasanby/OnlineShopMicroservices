using Cart.API.Cart.StoreCart.Models;

namespace Cart.API.Cart.StoreCart;

public sealed class StoreCartCommandHandler : ICommandHandler<StoreCartCommand, StoreCartResult>
{
    private readonly ICartRepository _cartRepository;

    public StoreCartCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<StoreCartResult> Handle(StoreCartCommand command, CancellationToken cancellationToken)
    {
        await _cartRepository.StoreCartAsync(command.Cart, cancellationToken);

        return new StoreCartResult(command.Cart.Username);
    }
}