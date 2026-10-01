using System.ComponentModel.DataAnnotations;

namespace Folio.Api.Models;

public class DiscoverySource
{
    [Key, MaxLength(100)] public string WorkId { get; set; } = "";
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
    public string Text { get; set; } = "";
    [MaxLength(2000)] public string? SourceUrl { get; set; }
    [MaxLength(1000)] public string Rights { get; set; } = "";
    [MaxLength(30)] public string TextType { get; set; } = "summary";
    public bool Generated { get; set; }
    public string EditionIdsJson { get; set; } = "[]";
    [MaxLength(64)] public string SourceHash { get; set; } = "";
    [MaxLength(64)] public string CatalogHash { get; set; } = "";
    [MaxLength(64)] public string IndexVersion { get; set; } = "";
    public string ProfileJson { get; set; } = "{}";
    public DateTime UpdatedAt { get; set; }
}

public class DiscoveryChunk
{
    [Key, MaxLength(140)] public string ChunkId { get; set; } = "";
    [MaxLength(100)] public string WorkId { get; set; } = "";
    public DiscoverySource Source { get; set; } = null!;
    public int Start { get; set; }
    public int End { get; set; }
    public string Text { get; set; } = "";
    [MaxLength(100)] public string? Chapter { get; set; }
}

public class DiscoveryFeedback
{
    public long Id { get; set; }
    [MaxLength(450)] public string UserId { get; set; } = "";
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
    [MaxLength(64)] public string IndexVersion { get; set; } = "";
    [MaxLength(20)] public string Feature { get; set; } = "";
    public bool Helpful { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
