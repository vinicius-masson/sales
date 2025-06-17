using FluentValidation;
using Sales.Domain.Entities;

namespace Sales.Domain.Validation
{
    public class SaleItemValidator : AbstractValidator<SaleItem>
    {
        public SaleItemValidator()
        {
            RuleFor(s => s.Quantity)
                .NotEmpty()
                .GreaterThan(0)
                .LessThanOrEqualTo(20)
                .WithMessage("Quantity cannot exceed 20.");

            RuleFor(s => s.UnitPrice)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Unit Price needs to be grater than 0");

            RuleFor(s => s.Discount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Discount needs to be grater than or equal 0");

            RuleFor(s => s.TotalPrice)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Total Price needs to be grater than or equal 0");

            RuleFor(s => s.Status)
                .IsInEnum()
                .WithMessage("Status needs to be Cancelled or NotCancelled");

            RuleFor(s => s.SaleId)
                .NotEmpty()
                .WithMessage("SaleId is Required");

            RuleFor(s => s.ProductId)
                .NotEmpty()
                .WithMessage("ProductId is Required");
        }
    }
}
