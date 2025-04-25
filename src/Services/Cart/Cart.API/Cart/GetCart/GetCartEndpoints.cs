using Cart.API.Cart.GetCart.Models;

namespace Cart.API.Cart.GetCart;

public sealed class GetCartEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{userName}", async (string userName, ISender sender) =>
        {
            var result = await sender.Send(new GetCartQuery(userName));

            var respose = result.Adapt<GetCartResponse>();

            return Results.Ok(respose);
        })
        .WithName("GetCartByUsername")
        .Produces<GetCartResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Cart by username")
        .WithDescription("Get Cart bu username");
    }
}