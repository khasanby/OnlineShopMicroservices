using FluentAssertions;
using Inventory.API.Products.CreateProduct;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using System.Net.Http.Json;

namespace Inventory.IntegrationTests.Products.CreateProduct;

public sealed class CreateProductEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CreateProductEndpointTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PostProduct_ValidRequest_Returns201()
    {
        // Arrange
        var request = new CreateProductRequest(
            Name: "Wireless Mouse",
            Tags: new List<string> { "electronics", "accessory", "wireless" },
            Description: "A sleek wireless mouse with ergonomic design and long battery life.",
            ImageFilePath: "/images/products/wireless_mouse.jpg",
            Price: 29.99m
        );

        // Act
        var response = await _client.PostAsJsonAsync("/products", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var responseBody = await response.Content.ReadFromJsonAsync<CreateProductResponse>();
        responseBody.Should().NotBeNull();
        responseBody.Name.Should().Be("Gaming Mouse");
    }
}