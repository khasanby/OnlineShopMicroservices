﻿namespace Inventory.API.Products.GetProducts;

public sealed class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products",
            async ([AsParameters] GetProductsRequest request, IDispatcher dispatcher) =>
            {
                GetProductsQuery query = new();
                GetProductsResult result = await dispatcher.Send(query);
                GetProductsResponse response = result.Adapt<GetProductsResponse>();
                return Results.Ok(response);
            })
            .WithName("GetProducts")
            .Produces<GetProductsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get all products")
            .WithDescription("Retrieves a list of all products in the inventory system.");
    }
}