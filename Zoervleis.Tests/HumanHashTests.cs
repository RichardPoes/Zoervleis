using System.Security.Cryptography;
using System.Text;
using Zoervleis.Exceptions;

namespace Zoervleis.Tests;

public class Tests
{
    [Test]
    [TestCase(new byte[] { 0, 1, 2, 3, 4, 5 }, "ack-alabama-alanine-alaska-alpha-angel")]
    [TestCase(new byte[] { 255, 255, 255, 255, 255, 255 }, "zulu-zulu-zulu-zulu-zulu-zulu")]
    public void HumanizesCorrectly(byte[] hash, string expected)
    {
        var humanizedString = HumanHash.Humanize(hash);
        
        Assert.That(humanizedString, Is.EqualTo(expected));
    }
    
    [Test]
    [TestCase(0, "")]
    [TestCase(6, "ack-alabama-alanine-alaska-alpha-angel")]
    [TestCase(8, "ack-alabama-alanine-alaska-alpha-angel-apart-april")]
    [TestCase(9, "ack-alabama-alanine-alaska-alpha-angel-apart-april")]
    public void UsingAmountOfWordsWorksCorrectly(int amountOfWords, string expected)
    {
        var hash = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 }; // Count = 8
        var humanizedString = HumanHash.Humanize(hash, amountOfWords);
        
        Assert.That(humanizedString, Is.EqualTo(expected));
    }
    
    [Test]
    public void ThrowsExceptionIfAmountOfWordsIsNegative()
    {
        var hash = new byte[] { 0 };
        
        Assert.Throws<AmountOfWordsMustBeNonNegativeException>(() => HumanHash.Humanize(hash, amountOfWords: - 1));
    }
    
    [Test]
    public void ThrowsExceptionIfNoHashProvided()
    {
        var hash = Array.Empty<byte>();
        
        Assert.Throws<NoHashProvidedException>(() => HumanHash.Humanize(hash));
    }
    
    [Test]
    public void ThrowsExceptionIfEmptyHashProvided()
    {
        Assert.Throws<NoHashProvidedException>(() => HumanHash.Humanize(null));
    }
}