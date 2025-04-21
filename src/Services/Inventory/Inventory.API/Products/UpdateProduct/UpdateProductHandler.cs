using Inventory.API.Infrastructure.Exceptions;

namespace Inventory.API.Products.UpdateProduct;

internal sealed class UpdateProductHandler(IDocumentSession session, ILogger<UpdateProductHandler> logger)
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(command.Name);
        if (product is null)
        {
            logger.LogWarning($"Product with ID {command.Name} not found");
            throw new ProductNotFoundException(command.Name);
        }

        product.Name = command.Name;
        product.Tags = command.Tags;
        product.Description = command.Description;
        product.ImageFilePath = command.ImageFilePath;
        product.Price = command.Price;

        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);
    }
}