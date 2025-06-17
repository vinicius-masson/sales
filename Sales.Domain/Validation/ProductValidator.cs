using FluentValidation;
using Sales.Domain.Entities;


namespace Sales.Domain.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.IsActive)
                .NotEmpty()
                .WithMessage("Product needs an status for active or inactive");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product name is required")
                .MinimumLength(5).WithMessage("Product must be at least 5 characters long.")
                .MaximumLength(50).WithMessage("Product cannot be longer than 30 characters.");

            RuleFor(p => p.BasePrice)
                .NotEmpty().WithMessage("Product price is required")
                .GreaterThan(0).WithMessage("Price needs to be greater than 0");
        }
    }
}
