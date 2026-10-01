using System.ComponentModel.DataAnnotations;

namespace Folio.Api.Models;

public class StoryTag
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
    [MaxLength(60)] public string Name { get; set; } = "";
}

public static class NarrativeTags
{
    public static readonly string[] All = ["Hero's Journey", "Enemies to Lovers", "Slow Burn", "Non-linear Timeline", "Unreliable Narrator", "In Media Res", "Cliffhanger Heavy", "Multiple POVs"];
}

public class Review
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
    [MaxLength(450)] public string UserId { get; set; } = "";
    public int Stars { get; set; }
    [MaxLength(5000)] public string Comment { get; set; } = "";
    public bool HasSpoilers { get; set; }
    public int? SpoilerChapter { get; set; }
    [MaxLength(20)] public string ModerationStatus { get; set; } = "Visible";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public List<ReviewVote> Votes { get; set; } = [];
    public List<ReviewFlag> Flags { get; set; } = [];
}

public class ReviewVote
{
    public int ReviewId { get; set; }
    public Review Review { get; set; } = null!;
    [MaxLength(450)] public string UserId { get; set; } = "";
    public int Value { get; set; }
}

public class ReviewFlag
{
    public int Id { get; set; }
    public int ReviewId { get; set; }
    public Review Review { get; set; } = null!;
    [MaxLength(450)] public string UserId { get; set; } = "";
    [MaxLength(500)] public string Reason { get; set; } = "";
    public bool Resolved { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class ReadingProgress
{
    public int Id { get; set; }
    [MaxLength(450)] public string UserId { get; set; } = "";
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
    [MaxLength(20)] public string Status { get; set; } = "want";
    public int CurrentPage { get; set; } = 1;
    public int FurthestPage { get; set; }
    public int CurrentChapter { get; set; }
    public int FurthestChapter { get; set; }
    public int TotalPages { get; set; }
    [MaxLength(2000)] public string? Location { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? FinishedAt { get; set; }
}

public class ReadingEvent
{
    public long Id { get; set; }
    [MaxLength(450)] public string UserId { get; set; } = "";
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
    public int PagesRead { get; set; }
    public DateTime Day { get; set; }
}

public class Bookmark
{
    public int Id { get; set; }
    [MaxLength(450)] public string UserId { get; set; } = "";
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
    public int Page { get; set; }
    public int Chapter { get; set; }
    [MaxLength(2000)] public string? Location { get; set; }
    [MaxLength(100)] public string Label { get; set; } = "Bookmark";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class JournalEntry
{
    public int Id { get; set; }
    [MaxLength(450)] public string UserId { get; set; } = "";
    [MaxLength(5000)] public string Content { get; set; } = "";
    [MaxLength(100)] public string ExtractedMood { get; set; } = "";
    [MaxLength(2000)] public string RecommendationSummary { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class MarginalNote
{
    public int Id { get; set; }
    [MaxLength(450)] public string UserId { get; set; } = "";
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
    [MaxLength(3000)] public string Body { get; set; } = "";
    public int Page { get; set; } = 1;
    public DateTime? UnlockAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

public class BookEmbedding
{
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
    [MaxLength(100)] public string Model { get; set; } = "";
    [MaxLength(64)] public string ContentHash { get; set; } = "";
    public string VectorJson { get; set; } = "[]";
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
