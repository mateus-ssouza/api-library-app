using ApiBiblioteca.Domain.Models;
using ApiBiblioteca.Domain.Models.Interfaces;
using ApiBiblioteca.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiBiblioteca.Infra.Repositories
{
    public class CopyRepository : ICopyRepository
    {
        private readonly Context _db;

        public CopyRepository(Context db)
        {
            _db = db;
        }

        public async Task<ICollection<Copy>> GetAll()
        {
            try
            {
                return await _db.Copies
                .Include(b => b.Book)
                .ToListAsync();
            }
            catch (Exception) { throw; }
        }

        public async Task<Copy> GetById(Guid id)
        {
            try
            {
                return await _db.Copies
                .Include(b => b.Book)
                .FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception) { throw; }   
        }

        public async Task<ICollection<Copy>> GetByBookId(Guid id)
        {
            try
            {
                return await _db.Copies
                    .Include(c => c.Book)
                    .Where(c => c.BookId == id)
                    .ToListAsync();
            }
            catch (Exception) { throw; }
        }

        public async Task<ICollection<Book>> GetAllBooksWithCopies()
        {
            try
            {
                return await _db.Books
                    .Where(book => book.Copies.Any())
                    .ToListAsync();
            }
            catch (Exception) { throw; }
        }

        public async Task<ICollection<Book>> GetBooksWithoutCopies()
        {
            try
            {
                return await _db.Books
                    .Where(book => !book.Copies.Any())
                    .ToListAsync();
            }
            catch (Exception) { throw; }
        }

        public async Task<bool> IsRegisteredCopyCode(string copyCode)
        {
            try
            {
                return await _db.Copies.AnyAsync(c => c.CopyCode == copyCode);
            }
            catch (Exception) { throw; }
        }

        public async Task Add(Copy model)
        {
            try
            {
                await _db.Copies.AddAsync(model);
                await _db.SaveChangesAsync();
            }
            catch (Exception) { throw; }  
        }

        public async Task Update(Guid id, Copy model)
        {
            try
            {
                var copyUpdate = await GetById(id);
                copyUpdate.CopyCode = model.CopyCode;
                copyUpdate.Available = model.Available;

                _db.Copies.Update(copyUpdate);
                await _db.SaveChangesAsync();
            }
            catch (Exception) { throw; }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var copy = await _db.Copies.FindAsync(id);
                _db.Copies.Remove(copy!);
                await _db.SaveChangesAsync();
            }
            catch (Exception) { throw; }
        }
    }
}
