namespace Inventory.API.Products.GetProductByName;

public sealed class GetProductByNameEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{name:string}",
            async (string name, GetProductByNameRequest request, IDispatcher dispatcher) =>
            {
                GetProductByNameResult result = await dispatcher.Send(new GetProductByNameQuery(name));
                GetProductByNameResponse response = result.Adapt<GetProductByNameResponse>();

                return Results.Ok(response);
            })
            .WithName("GetProductByName")
            .Produces<GetProductByNameResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .WithSummary("Get a product by its name")
            .WithDescription("Get a product by its name");
    }
}