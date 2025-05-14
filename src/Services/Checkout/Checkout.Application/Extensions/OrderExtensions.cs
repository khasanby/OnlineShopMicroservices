using Checkout.Application.Models;

namespace Checkout.Application.Extensions;

public static class OrderExtensions
{
    public static IEnumerable<Order> ToOrderDtoList(this IEnumerable<Order> orders)
    {
        return orders.Select(order => new Order(
            Id: order.Id,
            CustomerId: order.CustomerId,
            OrderName: order.OrderName,
            ShippingAddress: new Address(
                order.ShippingAddress.FirstName,
                order.ShippingAddress.LastName,
                order.ShippingAddress.EmailAddress!,
                order.ShippingAddress.AddressLine,
                order.ShippingAddress.Country,
                order.ShippingAddress.State,
                order.ShippingAddress.ZipCode
            ),
            BillingAddress: new Address(
                order.BillingAddress.FirstName,
                order.BillingAddress.LastName,
                order.BillingAddress.EmailAddress!,
                order.BillingAddress.AddressLine,
                order.BillingAddress.Country,
                order.BillingAddress.State,
                order.BillingAddress.ZipCode
            ),
            Payment: new Payment(
                order.Payment.CardName!,
                order.Payment.CardNumber,
                order.Payment.Expiration,
                order.Payment.Cvv,
                order.Payment.PaymentMethod
            ),
            Status: order.Status,
            OrderItems: order.OrderItems.Select(oi => new OrderItem(
                oi.OrderId, oi.ProductId, oi.Quantity, oi.Price)).ToList()
        ));
    }

    public static Order ToOrderDto(this Order order)
    {
        return DtoFromOrder(order);
    }

    private static Order DtoFromOrder(Order order)
    {
        return new Order(
                    Id: order.Id,
                    CustomerId: order.CustomerId,
                    OrderName: order.OrderName,
                    ShippingAddress: new Address(
                        order.ShippingAddress.FirstName,
                        order.ShippingAddress.LastName,
                        order.ShippingAddress.EmailAddress!,
                        order.ShippingAddress.AddressLine,
                        order.ShippingAddress.Country,
                        order.ShippingAddress.State,
                        order.ShippingAddress.ZipCode
                    ),
                    BillingAddress: new Address(
                        order.BillingAddress.FirstName,
                        order.BillingAddress.LastName,
                        order.BillingAddress.EmailAddress!,
                        order.BillingAddress.AddressLine,
                        order.BillingAddress.Country,
                        order.BillingAddress.State,
                        order.BillingAddress.ZipCode
                    ),
                    Payment: new Payment(
                        order.Payment.CardName!,
                        order.Payment.CardNumber,
                        order.Payment.Expiration,
                        order.Payment.Cvv,
                        order.Payment.PaymentMethod
                    ),
                    Status: order.Status,
                    OrderItems: order.OrderItems.Select(oi => new OrderItem(
                        oi.OrderId, oi.ProductId, oi.Quantity, oi.Price)).ToList()
        );
    }
}