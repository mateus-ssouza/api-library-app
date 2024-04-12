using ApiBiblioteca.Application.ViewModel;
using ApiBiblioteca.Domain.Enums;
using ApiBiblioteca.Domain.Models;

namespace ApiBiblioteca.Application.Utils
{
    public class CreateUtil
    {
        // Function to create loan instance
        public static Loan LoanCreate(LoanViewModel viewModel)
        {
            Loan loan = new()
            {
                LoanDate = viewModel.LoanDate,
                ReturnDate = viewModel.ReturnDate,
                Status = Status.Requested,
                BookLendings = viewModel.Books.Select(copyId =>
                {
                    return new BookLending { CopyId = copyId };
                }).ToList()
            };

            return loan;
        }

        public static Loan LoanCreate(LoanEditViewModel viewModel)
        {
            Loan loan = new()
            {
                ReturnDate = viewModel.ReturnDate,
            };

            return loan;
        }
    }
}
