namespace Inventory.API.Products.CreateProduct;

public sealed record CreateProductCommand(
    string Name,
    List<string> Tags,
    string Description,
    string ImageFilePath,
    decimal Price
) : ICommand<CreateProductResult>;

public sealed record CreateProductResult(string Name);