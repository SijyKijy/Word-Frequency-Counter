namespace WordFrequencyDictionary.Services;

/// <summary>
///     Represent provider to retrieve strings from text
/// </summary>
public interface ITextReaderProvider
{
    /// <summary>
    ///     Get a list of strings from the text
    /// </summary>
    IEnumerable<string> GetTextLines();
}
