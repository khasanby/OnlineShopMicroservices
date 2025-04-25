namespace Inventory.API.Products.CreateProduct;

public sealed class CreateProductHandler
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    private readonly IDocumentSession _documentSession;
    private readonly ILogger<CreateProductHandler> _logger;
    //private readonly IValidator<CreateProductCommand> _validator;

    public CreateProductHandler(IDocumentSession documentSession, ILogger<CreateProductHandler> logger)
    {
        _documentSession = documentSession;
        _logger = logger;
    }

    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating product with name: {Name}", command.Name);
        //ValidationResult validationResult = await _validator.ValidateAsync(command, cancellationToken);
        //if (!validationResult.IsValid)
        //{
        //    var errors = validationResult.Errors
        //        .Select(e => new ValidationFailure(e.PropertyName, e.ErrorMessage))
        //        .ToList();
        //    _logger.LogWarning("Validation failed for command: {Command}", command);
        //    _logger.LogWarning("Validation errors: {Errors}", errors);
        //    throw new ValidationException(validationResult.Errors);
        //}

        var product = new Product
        {
            Name = command.Name,
            Tags = command.Tags,
            Description = command.Description,
            ImageFilePath = command.ImageFilePath,
            Price = command.Price
        };

        _documentSession.Store(product);
        await _documentSession.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Name);
    }
}