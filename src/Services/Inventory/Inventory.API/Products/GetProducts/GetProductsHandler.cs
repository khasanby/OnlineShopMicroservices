namespace Inventory.API.Products.GetProducts;

internal sealed class GetProductsHandler
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    private readonly IDocumentSession _session;
    private readonly ILogger<GetProductsHandler> _logger;

    public GetProductsHandler(IDocumentSession session, ILogger<GetProductsHandler> logger)
    {
        _session = session;
        _logger = logger;
    }

    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling {QueryName}", nameof(GetProductsQuery));
        IPagedList<Product> products = await 
            _session.Query<Product>()
                    .ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, cancellationToken);

        return new GetProductsResult(products);
    }
}