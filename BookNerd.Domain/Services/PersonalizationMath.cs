namespace BookNerd.Domain.Services;

public static class PersonalizationMath
{
    public static double Content(bool genre, bool author, int matchingTags, double affinity) =>
        (genre ? 2 : 0) + (author ? 3 : 0) + Math.Min(matchingTags, 3) * .5 + Math.Max(0, affinity) * 2;

    // A neutral three-star prior prevents one five-star rating dominating mature evidence.
    public static double Community(int readers, int reviews, double rating) =>
        Math.Log2(1 + Math.Max(0, readers)) + Math.Log2(1 + Math.Max(0, reviews))
        + (reviews > 0 ? (reviews * rating + 5 * 3d) / (reviews + 5) / 5 : 0);
}
