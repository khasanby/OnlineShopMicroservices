namespace Inventory.API.Products.UpdateProduct;

public record UpdateProductCommand(
    string Name,
    List<string> Tags,
    string Description,
    string ImageFilePath,
    decimal Price
) : ICommand<UpdateProductResult>;

public record UpdateProductResult(bool IsSuccess);
