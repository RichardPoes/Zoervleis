using System;
using System.Text;
using Zoervleis.Exceptions;

namespace Zoervleis;

public static class HumanHash
{
    public static string Humanize(ReadOnlySpan<byte> hash, int amountOfWords = 6)
    {
        if (amountOfWords < 0) throw new AmountOfWordsMustBeNonNegativeException(amountOfWords);
        if (hash.Length == 0) throw new NoHashProvidedException();
        
        var sb = new StringBuilder();
        var wordsToGenerate = Math.Min(hash.Length, amountOfWords);
        
        for (var i = 0; i < wordsToGenerate; i++)
        {
            sb.Append(DefaultWords.English[hash[i]]);
            if (i < wordsToGenerate - 1)
            {
                sb.Append('-');
            }
        }
        
        return sb.ToString();
    }
}