namespace WordFrequencyDictionary.Services;

/// <summary>
///     Represents a service for counting the number of occurrences of words in a text
/// </summary>
public interface IWordCounter
{
    /// <summary>
    ///     Get a list of words with their number of occurrences
    /// </summary>
    IReadOnlyDictionary<string, int> GetWords();
}
