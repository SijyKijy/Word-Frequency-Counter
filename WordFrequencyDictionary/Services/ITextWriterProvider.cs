namespace WordFrequencyDictionary.Services;

/// <summary>
///     Represent provider to write words
/// </summary>
public interface ITextWriterProvider
{
    /// <summary>
    ///     Write words
    /// </summary>
    /// <param name="words">List of words with the number of occurrences</param>
    void Write(IEnumerable<KeyValuePair<string, int>> words);
}
