namespace Inventory.API.Products.GetProductByName;

internal sealed class GetProductByNameHandler
    : IQueryHandler<GetProductByNameQuery, GetProductByIdResult>
{
    private readonly IDocumentSession _session;
    private readonly ILogger<GetProductByNameHandler> _logger;

    public GetProductByNameHandler(IDocumentSession session, ILogger<GetProductByNameHandler> logger)
    {
        _session = session;
        _logger = logger;
    }

    public async Task<GetProductByNameResult> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling {QueryName}", nameof(GetProductByNameQuery));
        Product? product = await _session.LoadAsync<Product>(request.productName, cancellationToken);

        if (product is null)
        {
            _logger.LogWarning("Product with id {Name} not found", request.productName);
            throw new ProductNotFoundException($"Product with name {request.productName} not found.");
        }
        else
        {
            _logger.LogInformation("Product with name {Name} found", request.productName);
        }

        return new GetProductByNameResult(product)
            ?? throw new ProductNotFoundException($"Product with name {request.productName} not found.");
    }
}