using FluentValidation;
using Sales.Domain.Entities;

namespace Sales.Domain.Validation
{
    public class DiscountTierValidator : AbstractValidator<DiscountTier>
    {
        public DiscountTierValidator()
        {
            RuleFor(dt => dt.Quantity)
               .NotEmpty()
               .WithMessage("Quantity is required.")
               .GreaterThan(0)
               .WithMessage("Quantity must be greater than 0.");

            RuleFor(dt => dt.Percent)
               .NotEmpty()
               .WithMessage("Percent is required.")
               .GreaterThan(0)
               .WithMessage("Percent must be greater than 0.");
        }
    }
}
