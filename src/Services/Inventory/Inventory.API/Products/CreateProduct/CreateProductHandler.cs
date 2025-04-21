namespace Inventory.API.Products.CreateProduct;

internal sealed class CreateProductHandler(IDocumentSession documentSession)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = command.Name,
            Tags = command.Tags,
            Description = command.Description,
            ImageFilePath = command.ImageFilePath,
            Price = command.Price
        };

        documentSession.Store(product);
        await documentSession.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Name);
    }
}