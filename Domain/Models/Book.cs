using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiBiblioteca.Domain.Models
{
    public class Book
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Title { get; set; }

        [Required]
        [StringLength(60)]
        public string Author { get; set; }

        [Required]
        [StringLength(45)]
        public string ISBN { get; set; }

        [JsonIgnore]
        public ICollection<Copy> Copies { get; set; }
    }
}
