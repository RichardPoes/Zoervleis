using System.Diagnostics;
using System.Security.Cryptography;

namespace Zoervleis.IntegrationTests;

public class Tests
{
    [Test]
    public void StringToHumanHashWorks()
    {
        var toHash = "Hello World"u8.ToArray();
        var hash = SHA256.HashData(toHash);

        var humanizedString = HumanHash.Humanize(hash);

        Debug.WriteLine(humanizedString);
        Assert.That(humanizedString, Is.EqualTo("orange-monkey-oranges-steak-asparagus-white"));
    }

    [Test]
    public void StringToDigitHashWorks()
    {
        var toHash = "Hello World"u8.ToArray();
        var hash = SHA256.HashData(toHash);
        
        var humanizedString = DigitHash.Digitize(hash);
        
        Debug.WriteLine(humanizedString);
        Assert.That(humanizedString, Is.EqualTo("11109-73930-84387-59824-87079"));
    }
}