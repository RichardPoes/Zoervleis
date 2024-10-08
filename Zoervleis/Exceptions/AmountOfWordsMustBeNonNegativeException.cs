using System;

namespace Zoervleis.Exceptions;

public class AmountOfWordsMustBeNonNegativeException(int amountOfWords)
    : Exception($"Amount of words must be positive but was {amountOfWords}");