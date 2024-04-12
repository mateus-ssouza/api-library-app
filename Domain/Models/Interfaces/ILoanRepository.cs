namespace ApiBiblioteca.Domain.Models.Interfaces
{
    public interface ILoanRepository
    {
        Task Add(Loan model);
        Task Update(Guid id, Loan model);
        Task Delete(Guid id);
        Task<ICollection<Loan>> GetAll();
        Task<Loan> GetById(Guid id);
        Task<bool> LoanIsUser(Guid idUser, Guid idLoan);
        Task<bool> ExistsLoan(Guid id);
        Task<ICollection<Loan>> GetAllByUserId(Guid userId);
        Task Validate(Guid id);
        Task Finalize(Guid id);
    }
}
