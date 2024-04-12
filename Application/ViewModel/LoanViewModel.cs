namespace ApiBiblioteca.Application.ViewModel
{
    public class LoanViewModel
    {
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public ICollection<Guid> Books { get; set; }
    }
}
