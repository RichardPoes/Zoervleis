using System;
using System.Text;

namespace Zoervleis;

public static class HumanHash
{
    public static string Humanize(byte[] hash, int words = 6)
    {
        var sb = new StringBuilder();
        var wordsToGenerate = Math.Min(hash.Length, words);
        
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