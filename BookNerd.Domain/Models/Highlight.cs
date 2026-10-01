using System.ComponentModel.DataAnnotations;

namespace Folio.Api.Models;

public sealed class Highlight
{
    public int Id { get; set; }
    [MaxLength(450)] public string UserId { get; set; } = "";
    [MaxLength(80)] public string DocumentKey { get; set; } = "";
    [MaxLength(64)] public string ContentVersion { get; set; } = "";
    public int Page { get; set; }
    public int Start { get; set; }
    public int End { get; set; }
    [MaxLength(2000)] public string Quote { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
