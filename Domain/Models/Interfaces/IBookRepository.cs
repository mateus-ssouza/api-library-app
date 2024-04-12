namespace ApiBiblioteca.Domain.Models.Interfaces
{
    public interface IBookRepository
    {
        Task Add(Book model);
        Task Update(Guid id, Book model);
        Task Delete(Guid id);
        Task<ICollection<Book>> GetAll();
        Task<Book> GetById(Guid id);
    }
}
