namespace Inventory.API.Products.UpdateProduct;

public sealed class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products/{name:string}",
            async (Guid id, UpdateProductRequest request, ISender sender) =>
            {
                UpdateProductCommand command = request.Adapt<UpdateProductCommand>();
                UpdateProductResult result = await sender.Send(command);
                UpdateProductResponse response = result.Adapt<UpdateProductResponse>();

                return Results.Ok(response);
            })
            .WithName("UpdateProduct")
            .WithTags("Products")
            .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithSummary("Update a product")
            .WithDescription("Update a product in the inventory");
    }
}