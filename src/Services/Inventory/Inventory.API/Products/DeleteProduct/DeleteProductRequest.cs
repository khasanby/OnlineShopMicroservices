namespace Inventory.API.Products.DeleteProduct;

public record DeleteProductRequest(string Name);

public record DeleteProductResponse(bool IsSuccess);