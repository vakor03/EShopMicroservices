namespace Ordering.Domain.ValueObjects;

public record OrderItemId(Guid Value)
{
    public static OrderItemId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == Guid.Empty)
            throw new DomainException("Order Item Id cannot be empty");

        return new OrderItemId(value);
    }
}