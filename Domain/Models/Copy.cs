using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiBiblioteca.Domain.Models
{
    public class Copy
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(45)]
        public string CopyCode { get; set; }

        [Required]
        public bool Available { get; set; } = true;

        [Required]
        [ForeignKey("Book")]
        public Guid BookId { get; set; }

        [JsonIgnore]
        public Book Book { get; set; }

        [JsonIgnore]
        public ICollection<BookLending> BookLendings { get; set; }
    }
}
