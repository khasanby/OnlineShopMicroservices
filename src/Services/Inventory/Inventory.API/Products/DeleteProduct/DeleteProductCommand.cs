namespace Inventory.API.Products.DeleteProduct;

public record DeleteProductCommand(string Name) : ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSuccess);