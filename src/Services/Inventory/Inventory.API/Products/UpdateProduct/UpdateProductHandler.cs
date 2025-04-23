namespace Inventory.API.Products.UpdateProduct;

internal sealed class UpdateProductHandler
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    private readonly IDocumentSession _session;
    private readonly ILogger<UpdateProductHandler> _logger;

    public UpdateProductHandler(IDocumentSession session, ILogger<UpdateProductHandler> logger)
    {
        _session = session;
        _logger = logger;
    }

    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _session.LoadAsync<Product>(command.Name);
        if (product is null)
        {
            _logger.LogWarning($"Product with ID {command.Name} not found");
            throw new ProductNotFoundException(command.Name);
        }

        product.Name = command.Name;
        product.Tags = command.Tags;
        product.Description = command.Description;
        product.ImageFilePath = command.ImageFilePath;
        product.Price = command.Price;

        _session.Store(product);
        await _session.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);
    }
}