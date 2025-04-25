using FluentAssertions;
using Inventory.API.Entities;
using Inventory.API.Products.GetProductByName;
using Marten;
using Microsoft.Extensions.Logging;
using Moq;

namespace Inventory.UnitTests.Products.GetProductByName;

public sealed class GetProductByNameHandlerTests
{
    [Fact]
    public async Task Handle_ValidName_ReturnsProduct()
    {
        string productName = "Wireless Mouse";
        var query = new GetProductByNameQuery(productName);
        var fakeProduct = new Product();

        var sessionMock = new Mock<IDocumentSession>();
        var loggerMock = new Mock<ILogger<GetProductByNameHandler>>();

        sessionMock.Setup(x => x.LoadAsync<Product>(productName, CancellationToken.None))
                   .ReturnsAsync(fakeProduct);

        var handler = new GetProductByNameHandler(sessionMock.Object, loggerMock.Object);
        var result = await handler.Handle(query, CancellationToken.None);

        result.Should().NotBeNull();
        result.Product.Name.Should().Be(productName);
    }
}