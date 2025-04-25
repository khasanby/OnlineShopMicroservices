using FluentAssertions;
using Inventory.API.Products.CreateProduct;
using Marten;
using Microsoft.Extensions.Logging;
using Moq;

namespace Inventory.UnitTests.Products.CreateProduct;

public sealed class CreateProductHandlerTests
{
    [Fact]
    public async Task Handle_ValidCommand_StoresProductAndReturnsResult()
    {
        var command = new CreateProductCommand(
            Name: "Wireless Mouse",
            Tags: new List<string> { "electronics", "accessory", "wireless" },
            Description: "A sleek wireless mouse with ergonomic design and long battery life.",
            ImageFilePath: "/images/products/wireless_mouse.jpg",
            Price: 29.99m
        );

        var documentSessionMock = new Mock<IDocumentSession>();
        var loggerMock = new Mock<ILogger<CreateProductHandler>>();

        documentSessionMock.Setup(s => s.Store(It.IsAny<object>()));
        documentSessionMock.Setup(s => s.SaveChangesAsync(It.IsAny<CancellationToken>()))
                           .Returns(Task.CompletedTask);

        var handler = new CreateProductHandler(documentSessionMock.Object, loggerMock.Object);
        var testResult = await handler.Handle(command, CancellationToken.None);

        documentSessionMock.Verify(s => s.Store(It.IsAny<object>()), Times.Once);
        documentSessionMock.Verify(s => s.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);

        testResult.Should().NotBeNull();
        testResult.Name.Should().NotBeNullOrEmpty();
    }
}