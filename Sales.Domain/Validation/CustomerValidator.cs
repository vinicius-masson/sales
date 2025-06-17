using FluentValidation;
using Sales.Domain.Entities;

namespace Sales.Domain.Validation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Name)
                .NotEmpty().WithMessage("Name is Required.")
                .MinimumLength(5).WithMessage("Name must be at least 5 characters long.")
                .MaximumLength(50).WithMessage("Name cannot be longer than 50 characters.");

            RuleFor(customer => customer.Address)
                .NotEmpty()
                .WithMessage("Address is required");

            RuleFor(customer => customer.Document)
                .NotEmpty()
                .WithMessage("Document is Required");


            RuleFor(customer => customer.PersonType)
                .IsInEnum()
                .WithMessage("Person Type needs to be Natural or Legal");
        }
    }
}