using System.ComponentModel.DataAnnotations;

namespace Folio.Api.Models;

public class ReadingPreferences
{
    [Key, MaxLength(450)] public string UserId { get; set; } = "";
    public string GenreIdsJson { get; set; } = "[]";
    public string AuthorsJson { get; set; } = "[]";
    public string BookIdsJson { get; set; } = "[]";
    // An empty saved record means the reader explicitly skipped setup.
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
