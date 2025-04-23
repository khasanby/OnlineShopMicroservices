namespace Inventory.API.Products.CreateProduct;

public sealed record CreateProductRequest(
    string Name,
    List<string> Tags,
    string Description,
    string ImageFilePath,
    decimal Price
);

public sealed record CreateProductResponse(string Name);