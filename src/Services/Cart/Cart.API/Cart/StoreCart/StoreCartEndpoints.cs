using Cart.API.Cart.StoreCart.Models;

namespace Cart.API.Cart.StoreCart;

public sealed class StoreCartEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async (StoreCartRequest request, ISender sender) =>
        {
            var command = request.Adapt<StoreCartCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<StoreCartResponse>();

            return Results.Created($"/basket/{response.Username}", response);
        })
        .WithName("StoreCart")
        .Produces<StoreCartResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Store Cart")
        .WithDescription("Store Cart");
    }
}