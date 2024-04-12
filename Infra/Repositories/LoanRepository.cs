using ApiBiblioteca.Domain.Enums;
using ApiBiblioteca.Domain.Models;
using ApiBiblioteca.Domain.Models.Interfaces;
using ApiBiblioteca.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiBiblioteca.Infra.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly Context _db;

        public LoanRepository(Context db)
        {
            _db = db;
        }

        public async Task<ICollection<Loan>> GetAll()
        {
            try
            {
                return await _db.Loans
                .Include(l => l.User)
                .Include(bl => bl.BookLendings)
                .ThenInclude(bl => bl.Copy)
                .ThenInclude(c => c.Book)
                .ToListAsync();
            }
            catch (Exception) { throw; }
        }

        public async Task<ICollection<Loan>> GetAllByUserId(Guid userId)
        {
            try
            {
                return await _db.Loans
                    .Where(l => l.UserId == userId)
                    .Include(l => l.User)
                    .Include(bl => bl.BookLendings)
                    .ThenInclude(bl => bl.Copy)
                    .ThenInclude(c => c.Book)
                    .ToListAsync();
            }
            catch (Exception) { throw; }
        }

        public async Task<Loan> GetById(Guid id)
        {
            try
            {
                return await _db.Loans
                .Include(l => l.User)
                .Include(bl => bl.BookLendings)
                .ThenInclude(bl => bl.Copy)
                .ThenInclude(c => c.Book)
                .FirstOrDefaultAsync(l => l.Id == id);
            }
            catch (Exception) { throw; }   
        }

        public async Task Add(Loan model)
        {
            using var transaction = _db.Database.BeginTransaction();
            try
            {
                foreach (var copyLoan in model.BookLendings)
                {
                    var copy = await _db.Copies.FirstOrDefaultAsync(c => c.Id == copyLoan.CopyId && c.Available);

                    if (copy != null) copy.Available = false;
                    else throw new InvalidOperationException($"The copy with ID '{copyLoan.CopyId}' is not available for loan.");
                }

                _db.Loans.Add(model);
                await _db.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task Update(Guid id, Loan model)
        {
            using var transaction = _db.Database.BeginTransaction();
            try
            {
                var loanUpdate = await GetById(id);

                loanUpdate.ReturnDate = model.ReturnDate;

                _db.Loans.Update(loanUpdate);
                await _db.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task Delete(Guid id)
        {
            using var transaction = _db.Database.BeginTransaction();
            try
            {
                var loan = await _db.Loans
                    .Include(l => l.BookLendings)
                    .ThenInclude(bl => bl.Copy)
                    .FirstOrDefaultAsync(l => l.Id == id);

                if (loan == null) throw new InvalidOperationException($"Loan with ID '{id}' not found.");

                foreach (var copyLoan in loan.BookLendings)
                {
                    copyLoan.Copy.Available = true;
                }

                _db.Loans.Remove(loan);
                await _db.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task Validate(Guid id)
        {
            try
            {
                var loanValidate = await GetById(id);
                
                if (loanValidate.LoanDate < DateTime.Today)
                {
                    var differenceInDays = (loanValidate.ReturnDate - loanValidate.LoanDate).Days;
                    loanValidate.LoanDate = DateTime.Today;
                    loanValidate.ReturnDate = DateTime.Today.AddDays(differenceInDays);
                }

                loanValidate.Status = Status.InProgress;
                _db.Loans.Update(loanValidate);
                await _db.SaveChangesAsync();
            }
            catch (Exception) { throw; }
        }

        public async Task Finalize(Guid id)
        {
            try
            {
                var loanFinalize = await GetById(id);

                var differenceInDays = (DateTime.Today - loanFinalize.ReturnDate).Days;
                if (differenceInDays > 0)
                {
                    loanFinalize.Fines = differenceInDays * 0.3;
                }

                foreach (var copyLoan in loanFinalize.BookLendings)
                {
                    copyLoan.Copy.Available = true;
                }

                loanFinalize.Status = Status.Finished;
                _db.Loans.Update(loanFinalize);
                await _db.SaveChangesAsync();
            }
            catch (Exception) { throw; }
        }

        public async Task<bool> LoanIsUser(Guid idUser, Guid idLoan)
        {
            try
            {
                return await _db.Loans.AnyAsync(l => l.UserId == idUser && l.Id == idLoan);
            }
            catch (Exception) { throw; }
        }

        public async Task<bool> ExistsLoan(Guid id)
        {
            try
            {
                return await _db.Loans.AnyAsync(l => l.Id == id);
            }
            catch (Exception) { throw; }
        }
    }
}
