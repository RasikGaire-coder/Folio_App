using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;



namespace Folio.Api.Models
{
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }

        [Required(ErrorMessage = "Genre name is required")]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [JsonIgnore] 
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}

