using Inventory.API.Infrastructure.Exceptions;

namespace Inventory.API.Products.GetProductByName;

internal sealed class GetProductByNameHandler(IDocumentSession session, ILogger<GetProductByNameHandler> logger)
    : IQueryHandler<GetProductByNameQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling {QueryName}", nameof(GetProductByNameQuery));
        Product? product = await session.LoadAsync<Product>(request.Id, cancellationToken);

        if (product is null)
        {
            logger.LogWarning("Product with id {Id} not found", request.Id);
            throw new ProductNotFoundException($"Product with id {request.Id} not found.");
        }
        else
            logger.LogInformation("Product with id {Id} found", request.Id);

        return new GetProductByIdResult(product)
            ?? throw new ProductNotFoundException($"Product with id {request.Id} not found.");
    }
}