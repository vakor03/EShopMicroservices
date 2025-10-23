namespace Ordering.Domain.ValueObjects;

public record OrderName(string Value)
{
    private const int DEFAULT_LENGTH = 5;
    public static OrderName Of(string value)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(value);
        ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DEFAULT_LENGTH);
        
        return new OrderName(value);
    }
}