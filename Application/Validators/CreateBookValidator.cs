using ApiBiblioteca.Application.ViewModel;
using FluentValidation;

namespace ApiBiblioteca.Application.Validators
{
    public class CreateBookValidator : AbstractValidator<BookViewModel>
    {
        public CreateBookValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("Title is required")
                .Length(3, 80).WithMessage("Title must be between 3 and 80 characters ");

            RuleFor(b => b.Author)
                .NotEmpty().WithMessage("Author is required")
                .Length(3, 60).WithMessage("Author must be between 3 and 60 characters ");

            RuleFor(b => b.ISBN)
                .NotEmpty().WithMessage("ISBN is required")
                .Length(3, 45).WithMessage("ISBN must be between 3 and 45 characters ");
        }
    }
}
