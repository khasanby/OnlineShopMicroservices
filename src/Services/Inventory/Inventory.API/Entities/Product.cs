namespace Inventory.API.Entities;

public sealed class Product
{
    /// <summary>
    /// Gets or sets the id of a product.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Gets or sets the name of a product.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets categories where product belongs to.
    /// </summary>
    public List<string> Tags { get; set; } = new();

    /// <summary>
    /// Gets or sets description of a product.
    /// </summary>
    public string Description { get; set; } = default!;

    /// <summary>
    /// Gets or sets image file for a product.
    /// </summary>
    public string ImageFilePath { get; set; } = default!;
    
    /// <summary>
    /// Gets or sets price of a product.
    /// </summary>
    public decimal Price { get; set; }
}