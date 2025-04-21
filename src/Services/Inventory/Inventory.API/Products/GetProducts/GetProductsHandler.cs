namespace Inventory.API.Products.GetProducts;

internal sealed class GetProductsHandler(IDocumentSession session, ILogger<GetProductsHandler> logger)
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling {QueryName}", nameof(GetProductsQuery));
        IReadOnlyList<Product> products = await session.Query<Product>().ToListAsync(cancellationToken);

        return new GetProductsResult(products);
    }
}