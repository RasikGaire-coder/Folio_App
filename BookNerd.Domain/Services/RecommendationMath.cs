namespace BookNerd.Domain.Services;

public static class RecommendationMath
{
    public static double Affinity(float[] candidate, IReadOnlyList<float[]> references) =>
        references.Count == 0 ? 0 : references.Average(reference => Cosine(candidate, reference));

    public static double Cosine(float[] left, float[] right)
    {
        if (left.Length != right.Length || left.Length == 0) return 0;
        double dot = 0, a = 0, b = 0;
        for (var i = 0; i < left.Length; i++) { dot += left[i] * right[i]; a += left[i] * left[i]; b += right[i] * right[i]; }
        return a == 0 || b == 0 ? 0 : Math.Clamp(dot / Math.Sqrt(a * b), -1, 1);
    }
    public static double Trending(int readers, int pages, int reviews, double rating) =>
        readers * 3 + Math.Log2(1 + pages) + reviews * 2 + rating;

    public static bool HideSpoiler(bool shield, bool marked, int? spoilerChapter, int furthestChapter) =>
        shield && marked && (!spoilerChapter.HasValue || spoilerChapter > furthestChapter);
}
