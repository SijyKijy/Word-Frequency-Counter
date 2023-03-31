namespace WordFrequencyDictionary.Services;

public interface ITextWriterProvider
{
    void Write(IEnumerable<KeyValuePair<string, int>> words);
}
