using BuildingBlocks.CQRS.Handlers;
using Checkout.Application.Exceptions;
using Checkout.Domain.DataAccess;
using Checkout.Domain.ValueObjects;

namespace Checkout.Application.Orders.DeleteOrder;

public class DeleteOrderHandler(ICheckoutDbContext dbContext)
    : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
{
    public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        //Delete Order entity from command object
        //save to database
        //return result

        var orderId = OrderId.Of(command.OrderId);
        var order = await dbContext.Orders
            .FindAsync([orderId], cancellationToken: cancellationToken);

        if (order is null)
        {
            throw new OrderNotFoundException(command.OrderId.ToString());
        }

        dbContext.Orders.Remove(order);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteOrderResult(true);
    }
}