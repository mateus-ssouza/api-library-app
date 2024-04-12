using ApiBiblioteca.Application.ViewModel;
using FluentValidation;

namespace ApiBiblioteca.Application.Validators
{
    public class CreateCopyValidator : AbstractValidator<CopyViewModel>
    {
        public CreateCopyValidator()
        {
            RuleFor(c => c.CopyCode)
                .NotEmpty().WithMessage("CopyCode is required")
                .Length(3, 45).WithMessage("CopyCode must be between 3 and 45 characters ");
        }
    }
}
