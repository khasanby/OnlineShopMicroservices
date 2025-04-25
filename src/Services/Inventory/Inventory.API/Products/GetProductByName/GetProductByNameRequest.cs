namespace Inventory.API.Products.GetProductByName;

public record GetProductByNameRequest(string name);

public record GetProductByNameResponse(Product Product);