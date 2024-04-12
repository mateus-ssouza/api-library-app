using ApiBiblioteca.Domain.Enums;
using ApiBiblioteca.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBiblioteca.Infra.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Copy> Copies { get; set; }
        public DbSet<BookLending> BookLendings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the composite primary key for the BookLending join class
            modelBuilder.Entity<BookLending>()
                .HasKey(bl => new { bl.LoanId, bl.CopyId });

            // Configuring Many-to-Many Relationships
            modelBuilder.Entity<BookLending>()
                .HasOne(bl => bl.Loan)
                .WithMany(l => l.BookLendings)
                .HasForeignKey(bl => bl.LoanId);

            modelBuilder.Entity<BookLending>()
                .HasOne(bl => bl.Copy)
                .WithMany(b => b.BookLendings)
                .HasForeignKey(bl => bl.CopyId);

            // Leave the copyCode attribute unique
            modelBuilder.Entity<Copy>()
                .HasIndex(c => c.CopyCode).IsUnique();

            // Model creation data
            var b1 = new Book { Id = Guid.NewGuid(), Title = "O Hobbit", Author = "J.R.R. Tolkien", ISBN = "9780547928227" };
            var b2 = new Book { Id = Guid.NewGuid(), Title = "Um Feiticeiro de Terramar", Author = "Ursula K. Le Guin", ISBN = "9780547773742" };
            var b3 = new Book { Id = Guid.NewGuid(), Title = "As Aventuras de Alice no País das Maravilhas", Author = "Lewis Carroll", ISBN = "9780061121907" };
            var b4 = new Book { Id = Guid.NewGuid(), Title = "Jogos Vorazes", Author = "Suzanne Collins", ISBN = "9780439023528" };
            var b5 = new Book { Id = Guid.NewGuid(), Title = "Máquinas Mortais", Author = "Philip Reeve", ISBN = "9780060082070" };


            var c1 = new Copy{ Id = Guid.NewGuid(), CopyCode = "A001", Available = true, BookId = b1.Id };
            var c2 = new Copy { Id = Guid.NewGuid(), CopyCode = "A002", Available = true, BookId = b1.Id };
            var c3 = new Copy { Id = Guid.NewGuid(), CopyCode = "A003", Available = true, BookId = b1.Id };
            var c4 = new Copy { Id = Guid.NewGuid(), CopyCode = "A004", Available = true, BookId = b1.Id };
            
            var c5 = new Copy { Id = Guid.NewGuid(), CopyCode = "B001", Available = true, BookId = b2.Id };
            var c6 = new Copy { Id = Guid.NewGuid(), CopyCode = "B002", Available = true, BookId = b2.Id };
            var c7 = new Copy { Id = Guid.NewGuid(), CopyCode = "B003", Available = true, BookId = b2.Id };
            var c8 = new Copy { Id = Guid.NewGuid(), CopyCode = "B004", Available = true, BookId = b2.Id };

            var c9 = new Copy { Id = Guid.NewGuid(), CopyCode = "C001", Available = true, BookId = b3.Id };
            var c10 = new Copy { Id = Guid.NewGuid(), CopyCode = "C002", Available = true, BookId = b3.Id };
            var c11 = new Copy { Id = Guid.NewGuid(), CopyCode = "C003", Available = true, BookId = b3.Id };
            var c12 = new Copy { Id = Guid.NewGuid(), CopyCode = "C004", Available = true, BookId = b3.Id };

            var c13 = new Copy { Id = Guid.NewGuid(), CopyCode = "D001", Available = true, BookId = b4.Id };
            var c14 = new Copy { Id = Guid.NewGuid(), CopyCode = "D002", Available = true, BookId = b4.Id };
            var c15 = new Copy { Id = Guid.NewGuid(), CopyCode = "D003", Available = true, BookId = b4.Id };
            var c16 = new Copy { Id = Guid.NewGuid(), CopyCode = "D004", Available = true, BookId = b4.Id };

            var c17 = new Copy { Id = Guid.NewGuid(), CopyCode = "E001", Available = true, BookId = b5.Id };
            var c18 = new Copy { Id = Guid.NewGuid(), CopyCode = "E002", Available = true, BookId = b5.Id };
            var c19 = new Copy { Id = Guid.NewGuid(), CopyCode = "E003", Available = true, BookId = b5.Id };
            var c20 = new Copy { Id = Guid.NewGuid(), CopyCode = "E004", Available = true, BookId = b5.Id };

            modelBuilder.Entity<Book>().HasData(b1, b2, b3, b4, b5);
            modelBuilder.Entity<Copy>().HasData(c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20);
        }
    }
}
