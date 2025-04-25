namespace Inventory.API.Products.GetProductByName;

public record GetProductByNameQuery(string productName) : IQuery<GetProductByNameResult>;

public record GetProductByNameResult(Product Product);