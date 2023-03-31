using WordFrequencyDictionary.Models;

namespace WordFrequencyDictionary.Services;

public interface IWordCounter
{
    IReadOnlyDictionary<string, int> GetWords();
}
