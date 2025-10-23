using Ordering.Domain.Exceptions;

namespace Ordering.Domain.ValueObjects;

public record OrderId(Guid Value)
{
    public static OrderId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == Guid.Empty)
            throw new DomainException("Order Id cannot be empty");

        return new OrderId(value);
    }
}