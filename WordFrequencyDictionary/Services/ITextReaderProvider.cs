namespace WordFrequencyDictionary.Services;

public interface ITextReaderProvider
{
    IEnumerable<string> GetTextLines();
}
