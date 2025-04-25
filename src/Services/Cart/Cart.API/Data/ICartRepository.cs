using Cart.API.Entities;

namespace Cart.API.Data;

public interface ICartRepository
{
    public Task<ShoppingCart> GetCartAsync(string userName, CancellationToken cancellationToken = default);
    public Task<ShoppingCart> StoreCartAsync(ShoppingCart basket, CancellationToken cancellationToken = default);
    public Task<bool> DeleteCartAsync(string userName, CancellationToken cancellationToken = default);
}