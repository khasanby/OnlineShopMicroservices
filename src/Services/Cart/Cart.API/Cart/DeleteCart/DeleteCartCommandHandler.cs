using Cart.API.Cart.DeleteCart.Models;
using Cart.Domain.Data;

namespace Cart.API.Cart.DeleteCart;

public sealed class DeleteCartCommandHandler : ICommandHandler<DeleteCartCommand, DeleteCartResult>
{
    private readonly ICartRepository _cartRepository;

    public DeleteCartCommandHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<DeleteCartResult> Handle(DeleteCartCommand command, CancellationToken cancellationToken)
    {
        // TODO: delete cart from database and cache       
        await _cartRepository.DeleteCartAsync(command.Username, cancellationToken);

        return new DeleteCartResult(true);
    }
}