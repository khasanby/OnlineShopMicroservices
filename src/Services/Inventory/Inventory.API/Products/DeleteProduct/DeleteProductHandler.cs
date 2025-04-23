namespace Inventory.API.Products.DeleteProduct;

internal sealed class DeleteProductHandler
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    private readonly IDocumentSession _session;
    private readonly ILogger<DeleteProductHandler> _logger;

    public DeleteProductHandler(IDocumentSession session, ILogger<DeleteProductHandler> logger)
    {
        _session = session;
        _logger = logger;
    }

    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Deleting product with name: {Name}", command.Name);
        _session.Delete<Product>(command.Name);
        await _session.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Product with name: {Name} deleted successfully", command.Name);
        return new DeleteProductResult(true);
    }
}
