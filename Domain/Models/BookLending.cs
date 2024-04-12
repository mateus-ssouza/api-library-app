using System.Text.Json.Serialization;

namespace ApiBiblioteca.Domain.Models
{
    public class BookLending
    {
        public Guid LoanId { get; set; }
        [JsonIgnore]
        public Loan Loan { get; set; }

        public Guid CopyId { get; set; }
        public Copy Copy { get; set; }
    }
}
