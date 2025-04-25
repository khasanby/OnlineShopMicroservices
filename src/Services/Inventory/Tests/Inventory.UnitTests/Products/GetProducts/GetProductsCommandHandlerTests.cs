using FluentAssertions;
using Inventory.API.Entities;
using Inventory.API.Products.GetProducts;
using Marten;
using Marten.Linq;
using Microsoft.Extensions.Logging;
using MockQueryable;
using Moq;

namespace Inventory.UnitTests.Products.GetProducts;

public sealed class GetProductsCommandHandlerTests
{
    [Fact]
    public async Task Handle_WhenProductsExist_ReturnsAllProducts()
    {
        var fakeProducts = new List<Product>
        {
            new Product
            {
                Name = "Wireless Mouse",
                Description = "Ergonomic and wireless",
                Price = 29.99m
            },
            new Product
            {
                Name = "Mechanical Keyboard",
                Description = "RGB backlit keyboard",
                Price = 79.99m
            }
        };

        var queryable = fakeProducts.AsQueryable().BuildMock();
        var sessionMock = new Mock<IDocumentSession>();
        var martQueryableMock = new Mock<IMartenQueryable<Product>>();
        martQueryableMock.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(queryable.Provider);
        martQueryableMock.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(queryable.Expression);
        martQueryableMock.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
        martQueryableMock.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
        sessionMock.Setup(s => s.Query<Product>())
                   .Returns(martQueryableMock.Object);

        var loggerMock = new Mock<ILogger<GetProductsHandler>>();
        var handler = new GetProductsHandler(sessionMock.Object, loggerMock.Object);

        var query = new GetProductsQuery();
        var result = await handler.Handle(query, CancellationToken.None);

        result.Should().NotBeNull();
        result.Products.Should().HaveCount(2);

        sessionMock.Verify(s => s.Query<Product>(), Times.Once);
    }
}