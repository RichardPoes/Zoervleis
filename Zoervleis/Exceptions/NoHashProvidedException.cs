using System;

namespace Zoervleis.Exceptions;

public class NoHashProvidedException() : Exception("Hash was either null or empty.");