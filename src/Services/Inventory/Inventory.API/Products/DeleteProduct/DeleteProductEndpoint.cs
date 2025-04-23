namespace Inventory.API.Products.DeleteProduct;

public sealed class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/products/{name:string}",
            async (string name, IDispatcher dispatcher) =>
            {
                DeleteProductResult result = await dispatcher.Send(new DeleteProductCommand(name));
                DeleteProductResponse response = result.Adapt<DeleteProductResponse>();

                return Results.Ok(response);
            })
            .WithName("DeleteProduct")
            .WithTags("Products")
            .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete a product")
            .WithDescription("Delete a product by its ID.");
    }
}
