using Cart.Application.Exceptions;
using Cart.Domain.Data;
using Cart.Domain.Entities;
using Marten;

namespace Cart.Application.DataAccess;

public class CartRepository : ICartRepository
{
    private readonly IDocumentSession _session;

    public CartRepository(IDocumentSession session)
    {
        _session = session;
    }

    public async Task<ShoppingCart> GetCartAsync(string userName, CancellationToken cancellationToken = default)
    {
        var basket = await _session.LoadAsync<ShoppingCart>(userName, cancellationToken);

        return basket is null ? throw new CartNotFoundException(userName) : basket;
    }

    public async Task<ShoppingCart> StoreCartAsync(ShoppingCart basket, CancellationToken cancellationToken = default)
    {
        _session.Store(basket);
        await _session.SaveChangesAsync(cancellationToken);
        return basket;
    }

    public async Task<bool> DeleteCartAsync(string userName, CancellationToken cancellationToken = default)
    {
        _session.Delete<ShoppingCart>(userName);
        await _session.SaveChangesAsync(cancellationToken);
        return true;
    }
}