using System;
using System.Numerics;
using Zoervleis.Exceptions;

namespace Zoervleis;

public static class DigitHash
{
    public static string Digitize(ReadOnlySpan<byte> hash, int amountOfWords = 5, int wordLength = 5)
    {
        if (amountOfWords < 0) throw new AmountOfWordsMustBeNonNegativeException(amountOfWords);
        if(wordLength <= 0) throw new WordLengthMustBePositiveException(wordLength);
        if (hash.Length == 0) throw new NoHashProvidedException();
        
        var hashAsNumber = new BigInteger(hash, isUnsigned: true, isBigEndian: true);
        var digitizedHash = new string[amountOfWords];

        for (var i = 0; i < amountOfWords; i++)
        {
            var word = hashAsNumber % BigInteger.Pow(10, wordLength);
            digitizedHash[i] = word.ToString($"D{wordLength}");
            hashAsNumber /= BigInteger.Pow(10, wordLength);
        }
        
        Array.Reverse(digitizedHash); // We reverse the order such that least significant bit is on the right side
        return string.Join("-", digitizedHash);
    }
}