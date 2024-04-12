using ApiBiblioteca.Application.ViewModel;
using FluentValidation;

namespace ApiBiblioteca.Application.Validators
{
    public class LoginUserValidator : AbstractValidator<LoginViewModel>
    {
        public LoginUserValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required")
                .MaximumLength(60).WithMessage("Email supports a maximum of 60 characters")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required")
                .Length(4, 90).WithMessage("Password must be between 4 and 90 characters ");
        }
    }
}
