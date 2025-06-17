using FluentValidation;
using Sales.Domain.Entities;

namespace Sales.Domain.Validation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(sale => sale.Customer)
                .NotEmpty()
                .WithMessage("Customer is required.");


            RuleFor(sale => sale.BranchOffice)
                .NotEmpty()
                .WithMessage("Branch Office is required.");

            RuleFor(sale => sale.SaleItens)
                .NotEmpty()
                .WithMessage("Sale Itens is required.");

            RuleFor(sale => sale.TotalSaleAmount)
                .GreaterThan(0)
                .WithMessage("Total Sale Amount needs to be greater than 0");

            RuleFor(sale => sale.Status)
                .IsInEnum()
                .WithMessage("Status needs to be Cancelled or NotCancelled");
        }
    }
}
