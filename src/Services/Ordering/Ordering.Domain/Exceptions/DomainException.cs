﻿namespace Ordering.Domain.Exceptions;

public class DomainException : Exception
{
    public DomainException(string message) : base($"Domain exception: \"{message}\" thrown from a Domain Layer.")
    {
    }
}