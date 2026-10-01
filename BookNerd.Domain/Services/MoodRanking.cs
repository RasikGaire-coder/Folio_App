namespace BookNerd.Domain.Services;

public static class MoodRanking
{
    // Explicit, versioned parameters; evaluation/ reports contain sensitivity comparisons.
    public const double SemanticWeight = 0.65;
    public const double EmotionWeight = 0.35;
    public static double EmotionMatch(IReadOnlyDictionary<string, double> book, IReadOnlyDictionary<string, double> target)
    {
        var labels = target.Keys.Where(k => k != "neutral").ToArray();
        var a = labels.Select(k => (float)book.GetValueOrDefault(k)).ToArray();
        var b = labels.Select(k => (float)target[k]).ToArray();
        // Do not magnify a nearly neutral/unsupported emotion vector into strong evidence.
        return Math.Max(0, RecommendationMath.Cosine(a, b)) * Math.Min(1, a.Sum() / 0.25);
    }
    public static double Activation(IReadOnlyDictionary<string, double> emotions) =>
        Math.Clamp(new[] { "fear", "anger", "nervousness", "grief", "excitement" }.Sum(k => emotions.GetValueOrDefault(k)), 0, 1);
    public static double Score(double semantic, double emotional, double activation, double? tolerance, double preference = 0) =>
        SemanticWeight * Math.Clamp(semantic, 0, 1) + EmotionWeight * emotional
        - (tolerance.HasValue ? Math.Max(0, activation - tolerance.Value) * 0.4 : 0)
        + Math.Clamp(preference, 0, 1) * 0.05;
}
