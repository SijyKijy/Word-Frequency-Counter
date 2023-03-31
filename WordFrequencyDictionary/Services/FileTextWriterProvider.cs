using System.Text;

namespace WordFrequencyDictionary.Services;

public sealed class FileTextWriterProvider : ITextWriterProvider
{
    private readonly string _filePath;

    public FileTextWriterProvider(string filePath)
    {
        _filePath = filePath;
    }

    public void Write(IEnumerable<KeyValuePair<string, int>> words)
    {
        using StreamWriter sw = new(_filePath, false, Encoding.UTF8);
        foreach (var word in words)
        {
            sw.WriteLine("{0},{1}", word.Key, word.Value);
        }
    }
}
