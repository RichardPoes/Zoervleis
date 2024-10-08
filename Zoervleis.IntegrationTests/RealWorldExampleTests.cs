using System.Diagnostics;
using System.Security.Cryptography;

namespace Zoervleis.IntegrationTests;

public class Tests
{
    [Test]
    public void StringToHashWorks()
    {
        using var alg = SHA256.Create();
        var hash = "Hello World"u8.ToArray();
        
        var humanizedString = HumanHash.Humanize(hash);
        
        Debug.WriteLine(humanizedString);
        Assert.That(humanizedString, Is.EqualTo("fix-ink-juliet-juliet-kansas-cardinal"));
    }
}