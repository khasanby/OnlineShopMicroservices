namespace Inventory.API.Products.GetProductByName;

public record GetProductByNameRequest(Guid Id);

public record GetProductByIdResponse(Product Product);