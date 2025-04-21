
namespace Inventory.API.Products.DeleteProduct;

internal sealed class DeleteProductHandler(IDocumentSession session, ILogger<DeleteProductHandler> logger)
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting product with name: {Name}", command.Name);
        session.Delete<Product>(command.Name);
        await session.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Product with name: {Name} deleted successfully", command.Name);
        return new DeleteProductResult(true);
    }
}
