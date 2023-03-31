using System.Collections.Concurrent;
using WordFrequencyDictionary.Models;

namespace WordFrequencyDictionary.Services;

/// <summary>
///     Represents a parallel version <see cref="IWordCounter"/>
/// </summary>
public sealed class ParallelWordCounter : IWordCounter
{
    private readonly ITextReaderProvider _textReaderProvider;

    public ParallelWordCounter(ITextReaderProvider textReaderProvider)
    {
        _textReaderProvider = textReaderProvider;
    }

    public IReadOnlyDictionary<string, int> GetWords()
    {
        ConcurrentDictionary<string, CounterItem> wordCounts = new(StringComparer.OrdinalIgnoreCase);
        var parallelOptions = new ParallelOptions();

        Parallel.ForEach(_textReaderProvider.GetTextLines(), line =>
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
                        var item = wordCounts.GetOrAdd(word, _ => new());
                        item.Increment();
                    }
                    start = i + 1;
                }
            }

            if (span.Length > start)
            {
                string word = span[start..].ToString();
                var item = wordCounts.GetOrAdd(word, _ => new());
                item.Increment();
            }
        });

        return wordCounts.ToDictionary(k => k.Key, v => v.Value.Counter);
    }
}
