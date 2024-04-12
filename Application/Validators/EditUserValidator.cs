using ApiBiblioteca.Application.ViewModel;
using FluentValidation;

namespace ApiBiblioteca.Application.Validators
{
    public class EditUserValidator : AbstractValidator<UserEditViewModel>
    {
        public EditUserValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("Name is required")
                .Length(3, 45).WithMessage("Name must be between 3 and 45 characters");

            RuleFor(u => u.Cpf)
                .NotEmpty().WithMessage("Cpf is required")
                .Length(11).WithMessage("Cpf must have 11 digits");

            RuleFor(u => u.Birthday)
                .NotEmpty().WithMessage("Birthday is required")
                .Must(BeAValidDate).WithMessage("Birthday must be a valid date");

            When(u => u.Address != null, () =>
            {
                RuleFor(u => u.Address.Street)
                    .NotEmpty().WithMessage("Street is required")
                    .Length(3, 60).WithMessage("Street must be between 3 and 60 characters");

                RuleFor(u => u.Address.Number)
                    .NotEmpty().WithMessage("Number is required")
                    .MaximumLength(20).WithMessage("The Number must have a maximum of 20 characters");

                RuleFor(u => u.Address.Complement)
                    .NotEmpty().WithMessage("Complement is required")
                    .Length(3, 60).WithMessage("Complement must be between 3 and 60 characters");

                RuleFor(u => u.Address.City)
                    .NotEmpty().WithMessage("State is required")
                    .Length(3, 40).WithMessage("City must be between 3 and 40 characters");

                RuleFor(u => u.Address.State)
                    .NotEmpty().WithMessage("State is required")
                    .Length(2).WithMessage("State must have 2 digits");
            });
        }

        private bool BeAValidDate(DateTime date)
        {
            return date != default;
        }
    }
}
