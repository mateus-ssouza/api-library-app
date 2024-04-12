namespace ApiBiblioteca.Domain.Models.Interfaces
{
    public interface ICopyRepository
    {
        Task Add(Copy model);
        Task Update(Guid id, Copy model);
        Task Delete(Guid id);
        Task<ICollection<Copy>> GetAll();
        Task<Copy> GetById(Guid id);
        Task<bool> IsRegisteredCopyCode(string copyCode);
        Task<ICollection<Book>> GetAllBooksWithCopies();
        Task<ICollection<Book>> GetBooksWithoutCopies();
        Task<ICollection<Copy>> GetByBookId(Guid id);
    }
}
