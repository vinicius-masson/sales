using FluentValidation;
using Sales.Domain.Entities;

namespace Sales.Domain.Validation
{
    public class ProductCategoryValidator : AbstractValidator<ProductCategory>
    {
        public ProductCategoryValidator()
        {
            RuleFor(pc => pc.Name)
                .NotEmpty()
                .WithMessage("Product Category is required.");
        }
    }
}
