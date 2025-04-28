using Inventory.API.Exceptions;

namespace Inventory.API.Products.GetProductByName;

internal sealed class GetProductByNameHandler
    : IQueryHandler<GetProductByNameQuery, GetProductByNameResult>
{
    private readonly IDocumentSession _session;
    private readonly ILogger<GetProductByNameHandler> _logger;

    public GetProductByNameHandler(IDocumentSession session, ILogger<GetProductByNameHandler> logger)
    {
        _session = session;
        _logger = logger;
    }

    public async Task<GetProductByNameResult> Handle(GetProductByNameQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling {QueryName}", nameof(GetProductByNameQuery));
        Product? product = await _session.LoadAsync<Product>(query.productName, cancellationToken);

        if (product is null)
        {
            _logger.LogWarning("Product with id {Name} not found", query.productName);
            throw new ProductNotFoundException($"Product with name {query.productName} not found.");
        }
        else
        {
            _logger.LogInformation("Product with name {Name} found", query.productName);
        }

        return new GetProductByNameResult(product)
            ?? throw new ProductNotFoundException($"Product with name {query.productName} not found.");
    }
}