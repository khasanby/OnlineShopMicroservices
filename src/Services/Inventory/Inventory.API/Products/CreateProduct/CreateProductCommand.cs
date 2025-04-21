namespace Inventory.API.Products.CreateProduct;

public record CreateProductCommand(
    string Name,
    List<string> Tags,
    string Description,
    string ImageFilePath,
    decimal Price
) : ICommand<CreateProductResult>;

public record CreateProductResult(string Name);