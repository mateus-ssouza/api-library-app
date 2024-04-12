
using ApiBiblioteca.Domain.Enums;

namespace ApiBiblioteca.Domain.DTOs
{
    public class LoanDTO
    {
        public Guid Id { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Status Status { get; set; }
        public double Fines { get; set; }
        public string User { get; set; }
        public ICollection<BookDTO> Books { get; set; }
    }
}
