using System;

namespace Zoervleis.Exceptions;

public class WordLengthMustBePositiveException(int wordLength)
    : Exception($"Amount of words must be positive but was {wordLength}");