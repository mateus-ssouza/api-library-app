using ApiBiblioteca.Application.ViewModel;
using FluentValidation;

namespace ApiBiblioteca.Application.Validators
{
    public class RegisterUserValidator : AbstractValidator<UserViewModel>
    {
        public RegisterUserValidator() 
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

            RuleFor(u => u.UserType)
                .NotEmpty().WithMessage("UserType is required")
                .IsInEnum().WithMessage("Invalid user type");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required")
                .MaximumLength(60).WithMessage("Email supports a maximum of 60 characters")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required")
                .Length(4, 90).WithMessage("Password must be between 4 and 90 characters");

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
