using ApiBiblioteca.Domain.Models;
using ApiBiblioteca.Domain.Models.Interfaces;
using ApiBiblioteca.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiBiblioteca.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _db;

        public UserRepository(Context db)
        {
            _db = db;
        }

        public async Task<ICollection<User>> GetAll(Guid id)
        {
            try
            {
                return await _db.Users
                    .Where(u => u.Id != id)
                    .Include(u => u.Address)
                    .ToListAsync();
            }
            catch (Exception) { throw; }
        }


        public async Task<User> GetById(Guid id)
        {
            try
            {
                return await _db.Users
                .Include(u => u.Address)
                .FirstOrDefaultAsync(u => u.Id == id);
            }
            catch (Exception) { throw; }
        }

        public async Task<User> GetByEmail(string email)
        {
            try
            {
                return await _db.Users
                .Include(u => u.Address)
                .FirstOrDefaultAsync(u => u.Email == email);
            }
            catch (Exception) { throw; }
        }

        public async Task<bool> IsRegisteredEmail(string email)
        {
            try
            {
                return await _db.Users.AnyAsync(u => u.Email == email);
            }
            catch (Exception) { throw; }
        }

        public async Task Add(User model)
        {
            try
            {
                await _db.Users.AddAsync(model);
                await _db.SaveChangesAsync();
            }
            catch (Exception) { throw; }
        }

        public async Task Update(Guid id, User model)
        {
            
            try
            {
                var userUpdate = await GetById(id);

                userUpdate.Name = model.Name;
                userUpdate.Cpf = model.Cpf;
                userUpdate.Birthday = model.Birthday;
                userUpdate.UserType = model.UserType;
                userUpdate.Email = model.Email;
                userUpdate.Password = model.Password;
                userUpdate.Address = model.Address;

                _db.Users.Update(userUpdate);
                await _db.SaveChangesAsync();
            }
            catch (Exception) { throw; }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var user = await _db.Users.FindAsync(id);
                _db.Users.Remove(user!);
                await _db.SaveChangesAsync();
            }
            catch (Exception) { throw; }
        }

        public async Task<bool> ExistsUser(Guid id)
        {
            try
            {
                return await _db.Users.AnyAsync(u => u.Id == id);
            }
            catch (Exception) { throw; }
        }
    }
}
