namespace Inventory.API.Products.DeleteProduct;

[LogBehavior(LoggingType.Console)]
public record DeleteProductCommand(string Name) : ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSuccess);