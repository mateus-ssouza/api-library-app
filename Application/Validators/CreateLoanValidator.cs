using ApiBiblioteca.Application.ViewModel;
using FluentValidation;

namespace ApiBiblioteca.Application.Validators
{
    public class CreateLoanValidator : AbstractValidator<LoanViewModel>
    {
        public CreateLoanValidator()
        {
            RuleFor(l => l.LoanDate)
            .NotEmpty().WithMessage("LoanDate is required");

            RuleFor(l => l.ReturnDate)
                .NotEmpty().WithMessage("ReturnDate is required")
                .GreaterThan(l => l.LoanDate).WithMessage("The return date must be after the loan date.");

            RuleFor(l => l.Books)
                .NotEmpty().WithMessage("Books is required")
                .Must(l => l.Count > 0).WithMessage("The book list cannot be empty.");
        }
    }
}
