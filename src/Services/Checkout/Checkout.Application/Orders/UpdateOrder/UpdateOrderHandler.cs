using BuildingBlocks.CQRS.Handlers;
using Checkout.Application.Exceptions;
using Checkout.Application.Models;
using Checkout.Domain.DataAccess;
using Checkout.Domain.Entities;
using Checkout.Domain.ValueObjects;

namespace Checkout.Application.Orders.UpdateOrder;

public class UpdateOrderHandler(ICheckoutDbContext dbContext)
    : ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
{
    public async Task<UpdateOrderResult> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
    {
        //Update Order entity from command object
        //save to database
        //return result

        var orderId = OrderId.Of(command.Order.Id);
        var order = await dbContext.Orders
            .FindAsync([orderId], cancellationToken: cancellationToken);

        if (order is null)
        {
            throw new OrderNotFoundException(command.Order.Id.ToString());
        }

        UpdateOrderWithNewValues(order, command.Order);

        dbContext.Orders.Update(order);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateOrderResult(true);
    }

    public void UpdateOrderWithNewValues(OrderDB orderDB, Order order)
    {
        var updatedShippingAddress = Domain.ValueObjects.Address.Of(order.ShippingAddress.FirstName, order.ShippingAddress.LastName, order.ShippingAddress.EmailAddress, order.ShippingAddress.AddressLine, order.ShippingAddress.Country, order.ShippingAddress.State, order.ShippingAddress.ZipCode);
        var updatedBillingAddress = Domain.ValueObjects.Address.Of(order.BillingAddress.FirstName, order.BillingAddress.LastName, order.BillingAddress.EmailAddress, order.BillingAddress.AddressLine, order.BillingAddress.Country, order.BillingAddress.State, order.BillingAddress.ZipCode);
        var updatedPayment = Domain.ValueObjects.Payment.Of(order.Payment.CardName, order.Payment.CardNumber, order.Payment.Expiration, order.Payment.Cvv, order.Payment);

        orderDB.Update(
            orderName: OrderName.Of(order.OrderName),
            shippingAddress: updatedShippingAddress,
            billingAddress: updatedBillingAddress,
            payment: updatedPayment,
            status: order.Status);
    }
}