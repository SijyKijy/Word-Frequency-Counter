using Moq;
using WordFrequencyDictionary.Services;

namespace WordFrequencyDictionary.Tests;

public class WordCounterTests
{
    [Test]
    public void GetWords_WhenFileContainsWords_ReturnsCorrectWords()
    {
        // Arrange
        var textReaderProviderMock = new Mock<ITextReaderProvider>();
        textReaderProviderMock
            .Setup(e => e.GetTextLines())
            .Returns(new string[] { "Hello hi hello!", "   ", "    hElLo  HI   hello!!!!!" });

        IReadOnlyDictionary<string, int> expectedResult = new Dictionary<string, int>()
        {
            {"hello", 4},
            {"hi", 2}
        };

        IWordCounter wordCounter = new WordCounter(textReaderProviderMock.Object);

        // Act
        var actualWords = wordCounter.GetWords().OrderByDescending(k => k.Value);

        // Assert
        Assert.That(actualWords, Is.EqualTo(expectedResult).IgnoreCase);
    }

    [Test]
    public void GetWords_WhenFileContainsNoWords_ReturnsEmpty()
    {
        // Arrange
        var textReaderProviderMock = new Mock<ITextReaderProvider>();
        textReaderProviderMock
            .Setup(e => e.GetTextLines())
            .Returns(Array.Empty<string>());

        IReadOnlyDictionary<string, int> expectedResult = new Dictionary<string, int>();

        IWordCounter wordCounter = new WordCounter(textReaderProviderMock.Object);

        // Act
        var actualWords = wordCounter.GetWords().OrderByDescending(k => k.Value);

        // Assert
        Assert.That(actualWords, Is.EqualTo(expectedResult).IgnoreCase);
    }
}