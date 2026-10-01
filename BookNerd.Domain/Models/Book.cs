using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Folio.Api.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Book title is required")]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author name is required")]
        [StringLength(100)]
        public string Author { get; set; } = string.Empty;

        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int GenreId { get; set; }

        /// <summary>
        /// Enum mirror of GenreId. Stored as an int column in the database.
        /// Must stay in sync with GenreId.
        /// </summary>
        public BookGenre GenreType { get; set; }

        [StringLength(50)]
        public string CoverColor { get; set; } = "#244c3d";

        [StringLength(20)]
        public string? Badge { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public DateTime PublishedDate { get; set; }

        public DateTime CreatedDate { get; set; } = new(2026, 9, 10, 0, 0, 0, DateTimeKind.Utc);

        [MaxLength(20)] public string? Isbn { get; set; }
        [MaxLength(512)] public string? CoverKey { get; set; }
        [MaxLength(512)] public string? FileKey { get; set; }
        [MaxLength(12)] public string? FileFormat { get; set; }
        [MaxLength(100)] public string? License { get; set; }
        public bool IsFree { get; set; }
        public int ReadTimeMinutes { get; set; }
        public int ChapterCount { get; set; }
        public List<StoryTag> StoryTags { get; set; } = [];

        public int? RatingId { get; set; }

        [ForeignKey("RatingId")]
        public Rating? Rating { get; set; }

        [ForeignKey("GenreId")]
        public Genre? Genre { get; set; }

        [NotMapped]
        public decimal AverageRating => Rating?.AverageScore ?? 0;

        [NotMapped]
        public bool IsNew => (DateTime.Now - CreatedDate).TotalDays <= 30;

        [NotMapped]
        public bool IsTrending => Rating?.ReviewCount > 100;
    }
}
