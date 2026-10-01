namespace Folio.Api.Models
{
    /// <summary>
    /// Enum representation of book genres.
    /// Integer values intentionally match the seeded GenreId in the Genres table.
    /// </summary>
    public enum BookGenre
    {
        LiteraryFiction = 1,
        Fantasy         = 2,
        SciFi           = 3,
        Mystery         = 4,
        NonFiction      = 5,
        Historical      = 6,
        Romance         = 7,
        Thriller        = 8,
        Unclassified    = 9
    }
}
