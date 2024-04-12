namespace ApiBiblioteca.Domain.Models.Interfaces
{
    public interface IUserRepository
    {
        Task Add(User model);
        Task Update(Guid id, User model);
        Task Delete(Guid id);
        Task<ICollection<User>> GetAll(Guid id);
        Task<User> GetById(Guid id);
        Task<User> GetByEmail(string email); 
        Task<bool> IsRegisteredEmail(string email);
        Task<bool> ExistsUser(Guid id);
    }
}
