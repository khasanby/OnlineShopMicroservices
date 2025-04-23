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

    public async Task<GetProductByIdResult> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling {QueryName}", nameof(GetProductByNameQuery));
        Product? product = await _session.LoadAsync<Product>(request.Id, cancellationToken);

        if (product is null)
        {
            _logger.LogWarning("Product with id {Id} not found", request.Id);
            throw new ProductNotFoundException($"Product with id {request.Id} not found.");
        }
        else
        {
            _logger.LogInformation("Product with id {Id} found", request.Id);
        }

        return new GetProductByIdResult(product)
            ?? throw new ProductNotFoundException($"Product with id {request.Id} not found.");
    }
}