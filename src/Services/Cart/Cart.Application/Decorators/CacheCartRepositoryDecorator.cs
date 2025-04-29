using Cart.Domain.Data;
using Cart.Domain.Entities;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Cart.Application.Decorators;

public sealed class CacheCartRepositoryDecorator : ICartRepository
{
    private readonly ICartRepository _innerRepository;
    private readonly IDistributedCache _cache;

    public CacheCartRepositoryDecorator(ICartRepository innerRepository, IDistributedCache distributedCache)
    {
        _innerRepository = innerRepository;
        _cache = distributedCache;
    }

    /// <summary>
    /// Deletes the cart from the database and cache.
    /// </summary>
    public async Task<bool> DeleteCartAsync(string userName, CancellationToken cancellationToken = default)
    {
        Task removeCartTask = _innerRepository.DeleteCartAsync(userName, cancellationToken);
        Task removeCartFromCacheTask = _cache.RemoveAsync(userName, cancellationToken);
        await Task.WhenAll(new List<Task> { removeCartFromCacheTask, removeCartTask });

        return true;
    }

    /// <summary>
    /// Retrieves the cart from the cache if available, otherwise fetches it from the database.
    /// </summary>
    public async Task<ShoppingCart> GetCartAsync(string userName, CancellationToken cancellationToken = default)
    {
        var cachedCart = await _cache.GetStringAsync(userName, cancellationToken);
        if (!string.IsNullOrEmpty(cachedCart))
            return JsonSerializer.Deserialize<ShoppingCart>(cachedCart)!;

        var cartDb = await _innerRepository.GetCartAsync(userName, cancellationToken);
        await _cache.SetStringAsync(userName, JsonSerializer.Serialize(cartDb), cancellationToken);
        return cartDb;
    }

    /// <summary>
    /// Stores the cart in the database and cache.
    /// </summary>
    public async Task<ShoppingCart> StoreCartAsync(ShoppingCart cart, CancellationToken cancellationToken = default)
    {
        Task cartToDb = _innerRepository.StoreCartAsync(cart, cancellationToken);
        Task cartToCache = _cache.SetStringAsync(cart.Username, JsonSerializer.Serialize(cart), cancellationToken);
        await Task.WhenAll(new List<Task> { cartToCache, cartToDb });

        return cart;
    }
}