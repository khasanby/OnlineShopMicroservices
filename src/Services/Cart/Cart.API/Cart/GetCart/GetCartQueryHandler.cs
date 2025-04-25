using Cart.API.Cart.GetCart.Models;

namespace Cart.API.Cart.GetCart;

public sealed class GetCartQueryHandler : IQueryHandler<GetCartQuery, GetCartResult>
{
    private readonly ICartRepository _cartRepository;

    public GetCartQueryHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<GetCartResult> Handle(GetCartQuery query, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetCartAsync(query.Username);

        return new GetCartResult(cart);
    }
}