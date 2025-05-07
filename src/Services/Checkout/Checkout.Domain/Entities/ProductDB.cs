using Checkout.Domain.Abstractions;
using Checkout.Domain.ValueObjects;

namespace Checkout.Domain.Entities;

public sealed class ProductDB : Entity<ProductId>
{
    /// <summary>
    /// Gets or privately sets the product identifier.
    /// </summary>
    public string? Name { get; private set; }

    /// <summary>
    /// Gets or privately sets the product name.
    /// </summary>
    public decimal Price { get; private set; }


    public static ProductDB Create(ProductId id, string name, decimal price)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        var product = new ProductDB
        {
            Id = id,
            Name = name,
            Price = price
        };

        return product;
    }
}