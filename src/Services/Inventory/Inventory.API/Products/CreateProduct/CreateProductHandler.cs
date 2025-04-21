using BuildingBlocks.Abstractions.Handlers;
using Inventory.API.Entities;

namespace Inventory.API.Products.CreateProduct;

public sealed class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public CreateProductHandler()
    {

    }

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

        // save product to database.
        // return result.

        return new CreateProductResult(product.Name);
    }
}