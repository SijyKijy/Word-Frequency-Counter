namespace WordFrequencyDictionary.Models;

public class CounterItem
{
    private int _counter;

    public CounterItem()
    {
        _counter = 0;
    }

    public int Counter => _counter;

    public void Increment() => Interlocked.Increment(ref _counter);
}
