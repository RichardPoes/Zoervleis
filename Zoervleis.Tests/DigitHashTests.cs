using Zoervleis.Exceptions;

namespace Zoervleis.Tests;

public class DigitHashTests
{
    [Test]
    [TestCase(new byte[] { 0, 0, 0, 0, 0, 0 }, "00000-00000-00000-00000-00000")]
    [TestCase(new byte[] { 0, 0, 0, 0, 0, 1 }, "00000-00000-00000-00000-00001")]
    // // 2^(6 * 8) - 1 =  28147.49767.10655
    [TestCase(new byte[] { 255, 255, 255, 255, 255, 255 }, "00000-00000-28147-49767-10655")] 
    public void DigitizesCorrectly(byte[] hash, string expected)
    {
        var humanizedString = DigitHash.Digitize(hash);

        Assert.That(humanizedString, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(0, "")]
    [TestCase(2, "49767-10655")]
    [TestCase(3, "28147-49767-10655")]
    [TestCase(5, "00000-00000-28147-49767-10655")]
    [TestCase(8, "00000-00000-00000-00000-00000-28147-49767-10655")]
    public void UsingAmountOfWordsWorksCorrectly(int amountOfWords, string expected)
    {
        var hash = new byte[] { 255, 255, 255, 255, 255, 255 }; // Count = 6
        var humanizedString = DigitHash.Digitize(hash, amountOfWords: amountOfWords);

        Assert.That(humanizedString, Is.EqualTo(expected));
    }
    
    [Test]
    [TestCase(2, "49-76-71-06-55")]
    [TestCase(3, "281-474-976-710-655")]
    [TestCase(5, "00000-00000-28147-49767-10655")]
    [TestCase(8, "00000000-00000000-00000000-02814749-76710655")]
    public void UsingWordLengthWorksCorrectly(int wordLength, string expected)
    {
        var hash = new byte[] { 255, 255, 255, 255, 255, 255 }; // Count = 6
        var humanizedString = DigitHash.Digitize(hash, wordLength: wordLength);

        Assert.That(humanizedString, Is.EqualTo(expected));
    }

    [Test]
    public void ThrowsExceptionIfAmountOfWordsIsNegative()
    {
        var hash = new byte[] { 0 };
        
        Assert.Throws<AmountOfWordsMustBeNonNegativeException>(() => DigitHash.Digitize(hash, amountOfWords: - 1));
    }
    
    [Test]
    [TestCase(0)]
    [TestCase(-1)]
    public void ThrowsExceptionIfWordLengthIsNonPositive(int wordLength)
    {
        var hash = new byte[] { 0 };
        
        Assert.Throws<WordLengthMustBePositiveException>(() => DigitHash.Digitize(hash, wordLength: wordLength));
    }
    
    [Test]
    public void ThrowsExceptionIfNoHashProvided()
    {
        var hash = Array.Empty<byte>();
        
        Assert.Throws<NoHashProvidedException>(() => DigitHash.Digitize(hash));
    }
    
    [Test]
    public void ThrowsExceptionIfEmptyHashProvided()
    {
        Assert.Throws<NoHashProvidedException>(() => DigitHash.Digitize(null));
    }
}