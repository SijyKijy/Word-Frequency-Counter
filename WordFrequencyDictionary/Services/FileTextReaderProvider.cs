namespace WordFrequencyDictionary.Services;

public sealed class FileTextReaderProvider : ITextReaderProvider
{
    private readonly string _filePath;

    public FileTextReaderProvider(string filePath)
    {
        _filePath = filePath;
    }

    public IEnumerable<string> GetTextLines() => File.ReadLines(_filePath);
}
