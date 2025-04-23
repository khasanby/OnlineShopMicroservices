namespace Inventory.API.Products.CreateProduct;

public sealed class CreateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products",
            async (CreateProductRequest request, IDispatcher dispatcher) =>
            {
                CreateProductCommand command = request.Adapt<CreateProductCommand>();
                CreateProductResult result = await dispatcher.Send(command);
                CreateProductResponse response = result.Adapt<CreateProductResponse>();

                return Results.Created($"/products/{result.Name}", response);
            })
            .WithName("CreateProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create a new product")
            .WithDescription("Creates a new product in the inventory system.");
    }
}