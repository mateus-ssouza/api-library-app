namespace ApiBiblioteca.Domain.DTOs
{
    public class CopyDTO
    {
        public Guid Id { get; set; }
        public string CopyCode { get; set; }
        public bool Available { get; set; }
        public BookDTO Book { get; set; }
    }
}
