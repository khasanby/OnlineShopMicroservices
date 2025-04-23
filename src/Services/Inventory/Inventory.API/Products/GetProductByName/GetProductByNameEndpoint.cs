namespace Inventory.API.Products.GetProductByName;

public sealed class GetProductByNameEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{name:string}",
            async (Guid id, IDispatcher dispatcher) =>
            {
                GetProductByIdResult result = await dispatcher.Send(new GetProductByNameQuery(id));
                GetProductByIdResponse response = result.Adapt<GetProductByIdResponse>();

                return Results.Ok(response);
            })
            .WithName("GetProductById")
            .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithSummary("Get a product by its ID")
            .WithDescription("Get a product by its ID");
    }
}