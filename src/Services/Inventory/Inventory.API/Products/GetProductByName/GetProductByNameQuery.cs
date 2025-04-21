namespace Inventory.API.Products.GetProductByName;

public record GetProductByNameQuery(Guid Id) : IQuery<GetProductByIdResult>;

public record GetProductByIdResult(Product Product);