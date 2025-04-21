namespace Inventory.API.Products.GetProducts;

public record GetProductsRequest();

public record GetProductsResponse(IEnumerable<Product> Products);