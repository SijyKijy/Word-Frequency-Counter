namespace WordFrequencyDictionary.Services;

/// <summary>
///     Represents a simple version <see cref="IWordCounter"/>
/// </summary>
public sealed class WordCounter : IWordCounter
{
    private readonly ITextReaderProvider _textProvider;

    public WordCounter(ITextReaderProvider textProvider)
    {
        _textProvider = textProvider;
    }

    public IReadOnlyDictionary<string, int> GetWords()
    {
        Dictionary<string, int> wordCounts = new(StringComparer.OrdinalIgnoreCase);

        foreach (var line in _textProvider.GetTextLines())
        {
            ReadOnlySpan<char> span = line.AsSpan();
            int start = 0;
            for (int i = 0; i < span.Length; i++)
            {
                char c = span[i];
                if (!char.IsLetterOrDigit(c))
                {
                    if (i > start)
                    {
                        string word = span[start..i].ToString();
                        if (wordCounts.ContainsKey(word))
                        {
                            wordCounts[word]++;
                        }
                        else
                        {
                            wordCounts[word] = 1;
                        }
                    }
                    start = i + 1;
                }
            }

            if (span.Length > start)
            {
                string word = span[start..].ToString();
                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++;
                }
                else
                {
                    wordCounts[word] = 1;
                }
            }
        }

        return wordCounts;
    }
}
