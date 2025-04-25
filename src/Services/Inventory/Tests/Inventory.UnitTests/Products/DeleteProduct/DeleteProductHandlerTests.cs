using FluentAssertions;
using Inventory.API.Products.DeleteProduct;
using Marten;
using Microsoft.Extensions.Logging;
using Moq;

namespace Inventory.UnitTests.Products.DeleteProduct;

public sealed class DeleteProductHandlerTests
{
    [Fact]
    public async Task Handle_ValidCommand_DeletesProductAndReturnsResult()
    {
        // TODO: Name must be replaced with external id or something else unique.
        var command = new DeleteProductCommand(Name: "Wireless Mouse");

        var documentSessionMock = new Mock<IDocumentSession>();
        var loggerMock = new Mock<ILogger<DeleteProductHandler>>();

        documentSessionMock.Setup(s => s.Delete(It.IsAny<object>()));
        documentSessionMock.Setup(s => s.SaveChangesAsync(It.IsAny<CancellationToken>()))
                           .Returns(Task.CompletedTask);

        var handler = new DeleteProductHandler(documentSessionMock.Object, loggerMock.Object);
        var testResult = handler.Handle(command, CancellationToken.None);

        documentSessionMock.Verify(s => s.Delete(It.IsAny<object>()), Times.Once);
        documentSessionMock.Verify(s => s.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);

        testResult.Should().NotBeNull();
        testResult.Should().BeOfType<DeleteProductResult>();
    }
}