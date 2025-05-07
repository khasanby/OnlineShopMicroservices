namespace Checkout.Application.Models;

public sealed record OrderItem(
  Guid OrderId,
  Guid ProductId,
  int Quantity,
  decimal Price
);