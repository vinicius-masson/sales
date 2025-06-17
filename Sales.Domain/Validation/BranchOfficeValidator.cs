using FluentValidation;
using Sales.Domain.Entities;

namespace Sales.Domain.Validation
{
    public class BranchOfficeValidator : AbstractValidator<BranchOffice>
    {
        public BranchOfficeValidator()
        {
            RuleFor(b => b.Name)
               .NotEmpty()
               .WithMessage("Branch Office name is Required.");

            RuleFor(b => b.Adress)
               .NotEmpty()
               .WithMessage("Adress is Required.");
        }
    }
}
