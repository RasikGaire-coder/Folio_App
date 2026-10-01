namespace BookNerd.Domain.Services;

public interface IFileStorage
{
    Task<string> SaveAsync(Stream stream, string extension, string contentType, CancellationToken ct);
    Task<Stream?> OpenAsync(string key, CancellationToken ct);
    Task DeleteAsync(string key, CancellationToken ct);
}
