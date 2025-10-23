using Ordering.Domain.Exceptions;

namespace Ordering.Domain.ValueObjects;

public record CustomerId(Guid Value)
{
    public static CustomerId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == Guid.Empty)
            throw new DomainException("Customer Id cannot be empty");
        
        return new CustomerId(value);
    }
}