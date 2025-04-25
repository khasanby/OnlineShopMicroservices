using Cart.API.Cart.DeleteCart.Models;

namespace Cart.API.Cart.DeleteCart.Validators;

public sealed class DeleteCartCommandValidator : AbstractValidator<DeleteCartCommand>
{
    public DeleteCartCommandValidator()
    {
        RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required");
    }
}