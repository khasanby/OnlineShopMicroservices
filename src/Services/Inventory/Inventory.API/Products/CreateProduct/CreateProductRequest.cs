namespace Inventory.API.Products.CreateProduct;

public record CreateProductRequest(
    string Name,
    List<string> Tags,
    string Description,
    string ImageFilePath,
    decimal Price
);

public record CreateProductResponse(string Name);