using ApiBiblioteca.Domain.Models;
using ApiBiblioteca.Domain.Models.Interfaces;
using ApiBiblioteca.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiBiblioteca.Infra.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly Context _db;

        public BookRepository(Context db)
        {
            _db = db;
        }

        public async Task<ICollection<Book>> GetAll()
        {
            try
            {
                return await _db.Books.ToListAsync();
            }
            catch (Exception) { throw; }
        }

        public async Task<Book> GetById(Guid id)
        {
            try
            {
                return await _db.Books.FirstOrDefaultAsync(b => b.Id == id);
            }
            catch (Exception) { throw; }
        }

        public async Task Add(Book model)
        {
            try
            {
                await _db.Books.AddAsync(model);
                await _db.SaveChangesAsync();
            }
            catch (Exception) { throw; }
        }

        public async Task Update(Guid id, Book model)
        {
            try
            {
                var bookUpdate = await GetById(id);
                bookUpdate.Title = model.Title;
                bookUpdate.Author = model.Author;
                bookUpdate.ISBN = model.ISBN;

                _db.Books.Update(bookUpdate);
                await _db.SaveChangesAsync();
            }
            catch (Exception) { throw; }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var bookRemove = await GetById(id);
                 _db.Books.Remove(bookRemove);
                 await _db.SaveChangesAsync();
            }
            catch (Exception) { throw; }
        }
    }
}
