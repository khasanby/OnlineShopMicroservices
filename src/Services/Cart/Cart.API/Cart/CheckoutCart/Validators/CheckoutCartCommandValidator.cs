using Cart.API.Cart.CheckoutCart.Models;

namespace Cart.API.Cart.CheckoutCart.Validators;

public sealed class CheckoutCartCommandValidator : AbstractValidator<CheckoutCartCommand>
{
    public CheckoutCartCommandValidator()
    {
        RuleFor(cartCheckountCommand => cartCheckountCommand.CartCheckout)
            .NotNull()
            .WithMessage("CartCheckout can't be null");

        RuleFor(cartCheckountCommand => cartCheckountCommand.CartCheckout.UserName)
            .NotEmpty()
            .WithMessage("UserName is required");
    }
}