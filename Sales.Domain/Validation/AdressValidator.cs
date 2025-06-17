using FluentValidation;
using Sales.Domain.Entities;

namespace Sales.Domain.Validation
{
    public class AdressValidator : AbstractValidator<Adress>
    {
        public AdressValidator()
        {
            RuleFor(a => a.Street)
                .NotEmpty()
                .WithMessage("Street is Required.")
                .MinimumLength(4)
                .WithMessage("Street must be at least 4 characters long")
                .MaximumLength(30)
                .WithMessage("Street cannot be longer than 30 characters");

            RuleFor(a => a.Number)
                .NotEmpty()
                .WithMessage("Number is Required.")
                .GreaterThan(0)
                .WithMessage("Number must be greater than 0.")
                .Must(a => a.ToString().Length <= 5)
                .WithMessage("Number must have a maximum of 5 digits.");
        }
    }
}



