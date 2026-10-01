using System.ComponentModel.DataAnnotations;

namespace Folio.Api.Models
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Stars { get; set; }

        public decimal AverageScore { get; set; }

        [StringLength(500)]
        public string? ReviewText { get; set; }

        public int ReviewCount { get; set; }
    }
}
